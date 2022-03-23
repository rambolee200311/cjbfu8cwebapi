using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Diagnostics;
using CjbfU8CwebAPI;
using CjbfU8CwebAPI.Models;
using CjbfU8CwebAPI.Helper;
using CjbfU8CwebAPI.Models.PAY;
using CjbfU8CwebAPI.Models.CBA;
using CjbfU8CwebAPI.Models.Bank;
using CjbfU8CwebAPI.Models.Customer;
using CjbfU8CwebAPI.Models.Person;
namespace CjbfU8CwebAPI.Models.Fj
{
    public class FjInsert
    {
        string url = "https://api.yonyoucloud.com/apis/u8c/cmp/fj_insert";//请求接口地址
        string method = "POST";
        string apicode = "fb270bbfcfe4499294410fb23275e5dc"; //配置您申请的appkey
        string strSql = "";
        public void InsertFj(Pay item,Voucher voucher)
        {
            string strResult = "";
            LogHelper.Default.WriteInfo(JsonHelper.ToJson(item));
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory+"Helper/BaseData.xml");
                #region//客商
                    string custcode = "";//客商编码
                    CustomerQuery cq = new CustomerQuery();
                    custcode =cq.GetCustomer(item.ccusname);
                    if (custcode=="")
                    {
                        voucher.result = "0";
                        voucher.remark = item.ccusname + "在U8C客商档案里不存在";
                        return;
                    }
                #endregion

                #region//结算方式
                    string jsfs = "";
                    if (xmlDoc.SelectSingleNode("ufinterface//jsfs//type[@gld_code='"+item.csettletype+"']")!=null)
                    {
                        jsfs = xmlDoc.SelectSingleNode("ufinterface//jsfs//type[@gld_code='" + item.csettletype + "']").Attributes["u8c_code"].Value.ToString();
                    }
                    if (jsfs == "")
                    {
                        voucher.result = "0";
                        voucher.remark = item.csettletype + "未对照U8C结算方式档案";
                        return;
                    }
                #endregion

                #region//付款类型--收支项目
                    string szxm = "";
                    if (xmlDoc.SelectSingleNode("ufinterface//szxm//type[@gld_code='" + item.ccosttype + "']") != null)
                    {
                        szxm = xmlDoc.SelectSingleNode("ufinterface//szxm//type[@gld_code='" + item.ccosttype + "']").Attributes["u8c_code"].Value.ToString();
                    }
                    if (szxm == "")
                    {
                        voucher.result = "0";
                        voucher.remark = item.csettletype + "未对照U8C收支项目档案";
                        return;
                    }
                #endregion
                    ////add cust
                    //cbank
                    if ((jsfs == "004")||(jsfs=="00302"))//银企云联 电汇对私
                    {
                        if (string.IsNullOrWhiteSpace(item.cbank))
                        {
                            voucher.result = "0";
                            voucher.remark = "cbank开户银行不能为空";
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(item.cbankcode))
                        {
                            voucher.result = "0";
                            voucher.remark = "cbankcode联行号不能为空";
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(item.caccount))
                        {
                            voucher.result = "0";
                            voucher.remark = "caccount银行账户不能为空";
                            return;
                        }

                        //增加银行档案
                        BdBankDocRepository bdbankrepo = new BdBankDocRepository();
                        bdbankrepo.SaveBdBankDoc(item);
                        
                        //return;
                        //增加客户账户
                        //LogHelper.Default.WriteInfo("select b.custname from bd_custbank a"
                        //+ " inner join bd_cubasdoc b on a.pk_cubasdoc=b.pk_cubasdoc"
                        //+ " inner join bd_bankaccbas c on a.pk_accbank=c.pk_bankaccbas"
                        //+ " where b.custname!='" + item.ccusname + "' and c.accountcode='" + item.caccount + "' and c.accstate!=4");

                        //if (DataHelper.getStrResultFromSQLscript("select b.custname from bd_custbank a"
                        //+" inner join bd_cubasdoc b on a.pk_cubasdoc=b.pk_cubasdoc"
                        //+" inner join bd_bankaccbas c on a.pk_accbank=c.pk_bankaccbas"
                        //+" where b.custname!='"+item.ccusname+"' and c.accountcode='"+item.caccount+"' and c.accstate!=4","reader")!="")
                        //{
                        //    voucher.result = "0";
                        //    voucher.remark = "银行账户" + item.caccount + "已被其他客户使用";
                        //    return;
                        //}

                        //增加人员档案
                        if (jsfs=="00302")
                        {
                            PersonRepository.Add_Person(item);
                        }


                        //增加银行账户档案
                        strSql = "select pk_bankaccbas from [dbo].[bd_bankaccbas] where accountcode='" + item.caccount + "' and accountname='" + item.ccusname + "' and accstate!=4";
                        string pk_bankaccbas = DataHelper.getStrResultFromSQLscript(strSql, "reader");
                        if (string.IsNullOrEmpty(pk_bankaccbas))
                        {
                            strSql = "select pk_bankaccbas from [dbo].[bd_bankaccbas] where accountcode='" + item.caccount + "' and accstate!=4";
                            pk_bankaccbas = DataHelper.getStrResultFromSQLscript(strSql, "reader");
                            if (string.IsNullOrEmpty(pk_bankaccbas))
                            {
                                switch(jsfs)
                                {
                                    case "004"://银企云联
                                        CusBankAccountRepository.BscubasProc(item.ccusname, custcode, item.cbank, item.cbankcode, item.caccount, "busisness");
                                        break;
                                    case "00302"://电汇对私
                                        CusBankAccountRepository.BscubasProc(item.cperson, custcode, item.cbank, item.cbankcode, item.caccount, "individuals");
                                        break;
                                }
                               
                            }
                        }
                        //读取银行账户档案
                        strSql = "select pk_bankaccbas from [dbo].[bd_bankaccbas] where accountcode='" + item.caccount + "' and accountname='" + item.ccusname + "' and accstate!=4";
                        pk_bankaccbas = DataHelper.getStrResultFromSQLscript(strSql, "reader");
                        if (string.IsNullOrEmpty(pk_bankaccbas))
                        {
                            strSql = "select pk_bankaccbas from [dbo].[bd_bankaccbas] where accountcode='" + item.caccount + "' and accstate!=4";
                            pk_bankaccbas = DataHelper.getStrResultFromSQLscript(strSql, "reader");
                        }

                        switch (jsfs)
                        {
                            case "004"://银企云联
                                
                                //增加客户账户档案
                                if (!string.IsNullOrEmpty(pk_bankaccbas))
                                {
                                    strSql = "select pk_bankaccbas from [dbo].[bd_bankaccbas] where pk_bankaccbas='" + pk_bankaccbas + "' and accountname!='" + item.ccusname + "' and accstate!=4";
                                    if (!string.IsNullOrEmpty(DataHelper.getStrResultFromSQLscript(strSql, "reader")))
                                    {
                                        strSql = "update [dbo].[bd_bankaccbas] set accountname='" + item.ccusname + "' where  pk_bankaccbas='" + pk_bankaccbas + "'";
                                        LogHelper.Default.WriteInfo(strSql);
                                        DataHelper.getStrResultFromSQLscript(strSql, "nonquery");
                                    }
                                    //pk_bankaccbas = DataHelper.getStrResultFromSQLscript("select pk_bankaccbas from [dbo].[bd_bankaccbas] where accountcode='" + item.caccount + "' and accountname='" + item.ccusname + "'", "reader");
                                    string pk_cubasdoc = DataHelper.getStrResultFromSQLscript("select pk_cubasdoc from [dbo].[bd_cubasdoc] where custname='" + item.ccusname + "'", "reader");
                                    if ((!string.IsNullOrEmpty(pk_bankaccbas)) && (!string.IsNullOrEmpty(pk_cubasdoc)))
                                    {
                                        /*
                                         *2022-03-16 检查银行账号是否在客商档案里存在 
                                         */
                                        String countCustAcc = DataHelper.getStrResultFromSQLscript("select count(pk_custbank) pk_custbank from bd_custbank where pk_cubasdoc='" + pk_cubasdoc + "'", "reader");
                                        if (Convert.ToInt32(countCustAcc) == 0)
                                        {
                                            countCustAcc = DataHelper.getStrResultFromSQLscript("select count(pk_custbank) from bd_custbank where pk_accbank='"
                                                + pk_bankaccbas 
                                                //+ "select pk_bankaccbas from [dbo].[bd_bankaccbas] where accountcode='" + item.caccount + "' and accstate!=4"
                                                + "' and pk_cubasdoc='" + pk_cubasdoc + "'", "reader");
                                            if (countCustAcc == "0")
                                            {
                                                strSql = "insert into bd_custbank (defflag,pk_accbank,pk_cubasdoc,pk_custbank) values('N','" + pk_bankaccbas + "','" + pk_cubasdoc + "','" + pk_cubasdoc.Substring(0, 12) + pk_cubasdoc.Substring(16, 4) + pk_bankaccbas.Substring(16, 4) + "')";
                                                LogHelper.Default.WriteInfo(strSql);
                                                DataHelper.getStrResultFromSQLscript(strSql, "nonquery");
                                            }
                                        }
                                        else
                                        {
                                            countCustAcc = DataHelper.getStrResultFromSQLscript("select count(pk_custbank) from bd_custbank where pk_accbank in ("
                                                //+ pk_bankaccbas 
                                                + "select pk_bankaccbas from [dbo].[bd_bankaccbas] where accountcode='" + item.caccount + "' and accstate!=4"
                                                + ") and pk_cubasdoc='" + pk_cubasdoc + "'", "reader");
                                            if (countCustAcc == "0")
                                            {
                                                voucher.result = "0";
                                                voucher.remark = "银行账号不符请检查！";
                                                return;
                                            }
                                        }
                                    }
                                }
                                break;
                            case "00302"://电汇对私
                                //增加人员账户档案
                                if (!string.IsNullOrEmpty(pk_bankaccbas))
                                {
                                    strSql = "select pk_bankaccbas from [dbo].[bd_bankaccbas] where pk_bankaccbas='" + pk_bankaccbas + "' and accountname!='" + item.cperson + "' and accstate!=4";
                                    if (!string.IsNullOrEmpty(DataHelper.getStrResultFromSQLscript(strSql, "reader")))
                                    {
                                        strSql = "update [dbo].[bd_bankaccbas] set accountname='" + item.cperson + "' where  pk_bankaccbas='" + pk_bankaccbas + "'";
                                        LogHelper.Default.WriteInfo(strSql);
                                        DataHelper.getStrResultFromSQLscript(strSql, "nonquery");
                                    }
                                    strSql = "select pk_psnbasdoc from [dbo].[bd_psnbasdoc] where psnname='" + item.cperson + "' and pk_corp='1009'";
                                    LogHelper.Default.WriteInfo(strSql);
                                    string pk_cubasdoc = DataHelper.getStrResultFromSQLscript(strSql, "reader");
                                    if ((!string.IsNullOrEmpty(pk_bankaccbas)) && (!string.IsNullOrEmpty(pk_cubasdoc)))
                                    {
                                        if (DataHelper.getStrResultFromSQLscript("select 1 from bd_psnaccbank where pk_accbank='" + pk_bankaccbas + "' and pk_psnbasdoc='" + pk_cubasdoc + "'", "reader") == "")
                                        {
                                            strSql = "insert into bd_psnaccbank (dr,isreimburse,payacc,pk_accbank,pk_psnbasdoc,pk_psnaccbank) values (null,'N',null,'" + pk_bankaccbas + "','" + pk_cubasdoc + "','" + pk_cubasdoc.Substring(0, 12) + pk_cubasdoc.Substring(16, 4) + pk_bankaccbas.Substring(16, 4) + "')";
                                            LogHelper.Default.WriteInfo(strSql);
                                            DataHelper.getStrResultFromSQLscript(strSql, "nonquery");
                                        }
                                    }
                                }

                                break;
                        }
                    }
                    /*
                        parentvo.zyx1 = item.ccode;
                        parentvo.zyx2 = item.billModuleCode;
                        parentvo.zyx3 = item.billId; 
                     */
                    if (DataHelper.getStrResultFromSQLscript("select djbh from [dbo].[cmp_busibill] where dr!=1 and zyx1='" + item.ccode + "'"
                            +" and zyx2='"+item.billModuleCode+"'"
                            +" and zyx3='"+item.billId+"'", "reader")!="")
                        {
                            voucher.result = "1";
                            voucher.remark = "同步成功！";
                            //voucher.remark = "付款申请单据重复导入";
                            return;
                        }
                    
            try
            {
                //insert head
                var headerParams = new Dictionary<string, string>();
                headerParams.Add("apicode", apicode);
                headerParams.Add("system", "1");
                headerParams.Add("trantype", "code");
                //insert body
                FJ_billvo fjbillvo = new FJ_billvo();
                FJ_billvo_parentvo parentvo = new FJ_billvo_parentvo();
                parentvo.bzbm = "CNY";//币种编码
                parentvo.deptid = item.cprojectcode;//部门编码
                parentvo.bfyhzh = "11001028700056036151";//付款银行帐
                //if (jsfs == "004")//银企云联
                //{
                //    parentvo.dfyhzh = item.caccount;// "1234567";//收款银行账...
                //}
                parentvo.djbh = item.ccode;//单据号
                parentvo.djlxbm = "D5";//交易类型编...
                parentvo.djrq = DateTime.Now.ToShortDateString(); //item.ddate.ToShortDateString();//单据日期
                parentvo.dwbm = "001001";//公司编码
                parentvo.wldx = 1;//往来对象标...
                switch (jsfs)
                {
                    case "00302"://电汇对私
                        strSql = "select psncode from [dbo].[bd_psndoc] where psnname='" + item.cperson + "' and pk_corp='1009'";
                        //LogHelper.Default.WriteInfo(strSql);
                        parentvo.ywybm = DataHelper.getStrResultFromSQLscript(strSql,"reader");
                        break;
                    default://银企云联     
                        custcode = DataHelper.getStrResultFromSQLscript("select custcode from [dbo].[bd_cubasdoc] where custname='" + item.ccusname + "'", "reader");                       
                        parentvo.hbbm = custcode;//客商编码                        
                        break;
                }
                

                parentvo.lrr = "13810071974";//录入人编码
                parentvo.pj_jsfs = jsfs;//结算方式编...
                parentvo.prepay = false;//预收付标志
                parentvo.scomment = item.cmemo;//备注
                

                parentvo.zyx1 = item.ccode;
                parentvo.zyx2 = item.billModuleCode;
                parentvo.zyx3 = item.billId;
                parentvo.zyx4 = item.cperson;
                parentvo.zyx5 = item.cbank;
                parentvo.zyx6 = item.cbankcode;
                parentvo.zyx7 = item.caccount;
                parentvo.zyx11 = item.taxAmount.ToString();
                parentvo.zyx12 = item.expAccode;
                if (item.ccusname.IndexOf("预交") == 0)
                {
                    parentvo.zyx15 = "noneed";
                }
                else
                {
                    parentvo.zyx15 = "";
                }

                #region//回单备注
                    string hdbz = item.cprojectname + " " + item.cmemo;

                    parentvo.zyx8 = mySubString(hdbz, 0, 38);// + item.ccosttype + " 付款";
                #endregion

                fjbillvo.parentvo = parentvo;

                List<FJ_billvo_children> children = new List<FJ_billvo_children>();
                FJ_billvo_children child = new FJ_billvo_children();
                child.bbhl = 1;//本币
                child.szxmid = szxm;//收支项目编...
                child.jfybje = Convert.ToDouble(Math.Round(item.famount, 2, MidpointRounding.AwayFromZero)).ToString();//借方原币金...
                //child.jfybje = item.famount;
                child.kslb = 1;//扣税类别
                child.sl=0;//税率
                child.zyx1 = item.cprojectname;// DataHelper.getStrResultFromSQLscript(strSql, "reader");
                
                switch (jsfs)
                {
                    case "00302"://电汇对私
                        child.tradertype = "2";
                        child.zy = "代发其他";
                        //if (item.cprojectname.Length > 10)
                        //{
                        //    child.kxyt = item.cprojectname.Substring(0, 10) + " " + " 付款";
                        //}
                        //else
                        //{
                        //    child.kxyt = item.cprojectname+ " " + " 付款";
                        //}
                        break;
                    default://银企云联
                        child.tradertype = "0";
                        //2021-09-15 更新child.zy 项目名称+广联达备注 +付款
                        //child.zy = item.cprojectname + " " + item.ccosttype + " 付款";
                        hdbz = item.cprojectname + " " + item.cmemo + " 付款";
                        child.zy = mySubString(hdbz, 0, 38);
                        break;
                }


                if ((jsfs == "004") || (jsfs == "00302"))//银企云联 电汇对私
                {
                    child.dfyhzh = item.caccount;// "1234567";//收款银行账...
                }
                children.Add(child);
                fjbillvo.children = children;
                List<FJ_billvo> billvo = new List<FJ_billvo>();
                billvo.Add(fjbillvo);
                Fj_bill bill = new Fj_bill();
                bill.billvo = billvo;
                string bodyParams = JsonHelper.ToJson(bill);
                LogHelper.Default.WriteInfo(bodyParams);



                strResult = HttpPostHelper.sendInsert(url, bodyParams, headerParams, method);
                LogHelper.Default.WriteInfo( strResult);
                //2021-09-15 增加操作超时控制
                if (strResult.IndexOf("操作超时")>=0)
                {
                    voucher.result = "0";
                    voucher.remark = strResult + "<>同步失败！"; ;
                    voucher.JE = item.famount;
                    return;
                }
                else 
                { 
                    ResultProc.FjResultProc(voucher, strResult, item);
                }

            }
            catch(Exception ex)
            {
                voucher.result = "0";
                voucher.remark = ex.Message;
                LogHelper.Default.WriteError("FjInsert",ex);
                return;
            }
            finally
            {
                voucher.syncState = "add";
                voucher.syncTime = DateTime.Now;
            }
            //return strResult;
        }

        public string mySubString(string toSub, int startIndex, int length)
        {
            string Sub = "";
            byte[] subbyte = System.Text.Encoding.Default.GetBytes(toSub);
            if (subbyte.Length > length)
            {
                Sub = System.Text.Encoding.Default.GetString(subbyte, startIndex, length);
            }
            else
            {
                Sub = toSub;
            }

            return Sub;

        }

    }
}