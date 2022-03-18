using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CjbfU8CwebAPI.Models.BD;
using CjbfU8CwebAPI.Helper;
using System.Xml;


namespace CjbfU8CwebAPI.Models.CBA
{
    public class CusBankAccountRepository
    {
        public static void BscubasProc(string cCusname,string cCuscode,string cBank,string cBankCode,string cAccount,string cType)
        {
            string strSql = "";
            try
            {
                //use model
                CusBankAccount bscubas = new CusBankAccount();
                Ufinterface ufinterface = new Ufinterface();
                Basdoc basdoc = new Basdoc();
                Basdoc_head basdoc_head = new Basdoc_head();

                //assgin values
                //<ufinterface roottag="basdoc" billtype="bankaccount" replace="Y" receiver="0001" sender="1101" isexchange="Y" filename="银行账户数据文件.xml" proc="add">
                string Filename = "custbankaccount_";
                Filename += Guid.NewGuid();
                Filename += ".xml";
                //string cCuscode = MyRandom.GetMyRandom();
                ufinterface.roottag = "basdoc";
                ufinterface.billtype = "bankaccount";
                ufinterface.replace = "Y";
                ufinterface.receiver = "001001";
                ufinterface.sender = "gld";
                ufinterface.isexchange = "Y";
                ufinterface.filename = Filename;
                ufinterface.proc = "add";

                basdoc.id = cAccount;
                switch(cType)
                {
                    case "busisness":
                        basdoc_head.accclass="2";//busisness
                        basdoc_head.accountproperty = "0";//business
                        basdoc_head.custcode = cCuscode;
                        basdoc_head.pk_psnbasdoc = "";
                        break;
                    case "individuals":
                        basdoc_head.accclass = "2";//individuals
                        basdoc_head.accountproperty="1";//individuals
                        strSql = "select psncode from [dbo].[bd_psndoc] where psnname='" + cCusname + "' and pk_corp='1009'";
                        LogHelper.Default.WriteInfo(strSql);
                        basdoc_head.pk_psnbasdoc = DataHelper.getStrResultFromSQLscript(strSql, "reader");
                        break;
                }
               //<!--账户分类,最大长度为2,类型为:Integer-->
               //<accclass>1</accclass>
               //basdoc_head.accclass="2";//busisness
               //basdoc_head.accclass = "1";//individuals
               //<!--账户性质,最大长度为2,类型为:Integer-->
               //<accountproperty>0</accountproperty>
               //basdoc_head.accountproperty = "0";//business
               //basdoc_head.accountproperty="1"//individuals



                //<!--开户日期,最大长度为10,类型为:Date-->
                //<accopendate>2008-10-29</accopendate>
                basdoc_head.accopendate=DateTime.Now.ToShortDateString();
                    //<!--账号,不能为空,最大长度为100,类型为:String-->
                    //<account>account</account>
                basdoc_head.account=cAccount;
                    //<!--账户编码,不能为空,最大长度为40,类型为:String-->
                    //<accountcode>account_code</accountcode>
                basdoc_head.accountcode=cAccount;
                    //<!--账户名称,不能为空,最大长度为200,类型为:String-->
                    //<accountname>account_name</accountname>
                basdoc_head.accountname = cCusname;// +"_" + cAccount;
                    
                
                    //<!--账户状态,最大长度为2,类型为:Integer-->
                    //<accstate>0</accstate>
                basdoc_head.accstate="0";
                    //<!--账户类型,不能为空,最大长度为2,类型为:Integer-->
                    //<acctype>0</acctype>
                basdoc_head.acctype = "0";
                    //<!--收付属性,最大长度为2,类型为:Integer-->
                    //<arapprop>2</arapprop>
                basdoc_head.arapprop = "2";
                     //<!--联行号,最大长度为80,类型为:String-->
                    //<combineaccnum></combineaccnum>
                //<!--开户银行,最大长度为20,类型为:String-->
                //<pk_bankdoc></pk_bankdoc>
                //银行名称
                string bankdocname = DataHelper.getStrResultFromSQLscript("SELECT pcombinename FROM bd_pcombineinfo  where pcombinenum='" + cBankCode + "'", "reader");
                if (bankdocname != "")
                {
                    basdoc_head.pk_bankdoc = bankdocname;
                }
                else
                {
                    basdoc_head.pk_bankdoc = cBank;
                }

                basdoc_head.combineaccnum = cBankCode;
                     //<!--创建时间,最大长度为19,类型为:String-->
                    //<createtime></createtime>
                basdoc_head.createtime=DateTime.Now.ToLongDateString();
                    //<!--创建人,最大长度为20,类型为:String-->
                    //<creator></creator>
                basdoc_head.creator = "13501036623";
                    //<!--客户编码,最大长度为40,类型为:String-->
                    //<custcode></custcode>
                
                    //<!--资金形态,最大长度为2,类型为:Integer-->
                    //<fundform>1</fundform>
                basdoc_head.fundform="1";
                    //<!--总分属性,最大长度为2,类型为:Integer-->
                    //<genebranprop>2</genebranprop>
                basdoc_head.genebranprop="2";
                    //<!--集团账户,最大长度为1,类型为:Boolean-->
                    //<groupaccount>N</groupaccount>
                basdoc_head.groupaccount="N";
                    //<!--是否内部账户,最大长度为1,类型为:Boolean-->
                    //<isinneracc>N</isinneracc>
                basdoc_head.isinneracc = "N";
                     //<!--网银开通状态,最大长度为2,类型为:Integer-->
                    //<netqueryflag>0</netqueryflag>
                basdoc_head.netqueryflag = "0";
                    //<!--银行类别,不能为空,最大长度为20,类型为:String-->

                string pk_banktype = DataHelper.getStrResultFromSQLscript("SELECT banktypecode from bd_banktype where pk_banktype in (SELECT pk_banktype FROM bd_pcombineinfo  where pcombinenum='" + cBankCode + "')", "reader");
                if (pk_banktype == "")
                { pk_banktype = "313"; }
                basdoc_head.pk_banktype = pk_banktype;//"0001ZZ1000000001OCUC";
                    //<!--公司主键,最大长度为4,类型为:String-->
                    //<pk_corp>0001</pk_corp>
                basdoc_head.pk_corp = "001001";
                    //<!--币种,不能为空,最大长度为20,类型为:String-->
                    //<pk_currtype>CNY</pk_currtype>
                basdoc_head.pk_currtype = "CNY";
                    //<!--是否签约,最大长度为1,类型为:Boolean-->
                    //<signflag>0</signflag>
                basdoc_head.signflag = "0";
                    //<!--单位名称,最大长度为100,类型为:String-->
                    //<unitname></unitname>
                basdoc_head.unitname = cCusname;
                basdoc_head.ownercorp = "001001";
                //put to EAI
                basdoc.basdoc_head = basdoc_head;
                ufinterface.basdoc = basdoc;
                bscubas.ufinterface = ufinterface;
                string strResult = ObjToXml.CmpObjToXml(bscubas, Filename);
                LogHelper.Default.WriteInfo(strResult);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strResult.Replace("\r", "").Replace("\n", ""));
                xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory+ "temp\\result_" + Filename);
            }
            catch(Exception ex)
            {
                //do nothing
                LogHelper.Default.WriteError("CusBankAccountRepository", ex);
            }
        }
    }
}