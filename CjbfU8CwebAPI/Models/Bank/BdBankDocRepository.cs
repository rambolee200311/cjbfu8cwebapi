using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CjbfU8CwebAPI;
using CjbfU8CwebAPI.Models;
using CjbfU8CwebAPI.Helper;
using CjbfU8CwebAPI.Models.PAY;

namespace CjbfU8CwebAPI.Models.Bank
{
    public class BdBankDocRepository
    {
        string url = "https://api.yonyoucloud.com/apis/u8c/uapbd/bdbankdoc_save";//请求接口地址
        string method = "POST";
        string apicode = "fe0f18f081a347e6a414011765ce0d91"; //配置您申请的appkey

        public void SaveBdBankDoc(Pay item)//增加银行档案
        {
            BdBankDoc bdbankdoc = new BdBankDoc();
            List<BankDoc> bankdoclist = new List<BankDoc>();
            BankDoc bankdoc = new BankDoc();
            
            try
            {
                //select * from bd_bankdoc where bankdoccode='102100020778' or pcombinenum='102100020778'
                LogHelper.Default.WriteInfo("select bankdoccode from bd_bankdoc where bankdoccode='" + item.cbankcode + "' or pcombinenum='" + item.cbankcode + "'");
                if (DataHelper.getStrResultFromSQLscript("select bankdoccode from bd_bankdoc where bankdoccode='" + item.cbankcode + "' or pcombinenum='" + item.cbankcode + "'", "reader") == "")
                {
                    //save head
                    var headerParams = new Dictionary<string, string>();
                    headerParams.Add("apicode", apicode);
                    headerParams.Add("system", "1");
                    headerParams.Add("trantype", "code");
                    headerParams.Add("authoration", "apicode");
                    //save body
                    bankdoc.bankdoccode = item.cbankcode;
                    //银行名称
                    string bankdocname = DataHelper.getStrResultFromSQLscript("SELECT pcombinename FROM bd_pcombineinfo  where pcombinenum='" + item.cbankcode + "'", "reader");
                    if (bankdocname != "")
                    {
                        bankdoc.bankdocname = bankdocname;
                        bankdoc.pcombinename = bankdocname;
                        bankdoc.pcombinenum = item.cbankcode;
                    }
                    else
                    { bankdoc.bankdocname = item.cbank; }
                    bankdoc.shortname = item.cbank;
                    //联行号主键
                    string pk_pcombine = DataHelper.getStrResultFromSQLscript("SELECT pk_pcombineinfo FROM bd_pcombineinfo  where pcombinenum='" + item.cbankcode + "'", "reader");
                    if (pk_pcombine != "")
                    { bankdoc.pk_pcombine = pk_pcombine; }
                    //bankdoc.banktypecode = "qt";
                    //string pk_banktype = DataHelper.getStrResultFromSQLscript("select pk_banktype from bd_banktype where CHARINDEX(banktypename,'"+item.cbank+"')=1", "reader");
                    //银行类别
                    string pk_banktype = DataHelper.getStrResultFromSQLscript("SELECT pk_banktype FROM bd_pcombineinfo  where pcombinenum='" + item.cbankcode + "'", "reader");
                    if (pk_banktype != "")
                    { bankdoc.pk_banktype = pk_banktype; }
                    else//QT 商业银行
                    { bankdoc.pk_banktype = "0001F81000000000MNAU"; }
                    //省
                    string province = DataHelper.getStrResultFromSQLscript("SELECT province FROM bd_pcombineinfo  where pcombinenum='" + item.cbankcode + "'", "reader");
                    if (province != "")
                    { bankdoc.province = province; }
                    //市
                    string city = DataHelper.getStrResultFromSQLscript("SELECT city FROM bd_pcombineinfo  where pcombinenum='" + item.cbankcode + "'", "reader");
                    if (city != "")
                    { bankdoc.city = city; }

                    bankdoc.iscustbank = "false";
                    bankdoc.pk_corp = "0001";
                    bankdoc.unitcode = "0001";
                    //bankdoc.pk_pcombine = item.cbankcode;
                    //准备数据
                    bankdoclist.Add(bankdoc);
                    bdbankdoc.bankdoc = bankdoclist;
                    //bdbankdoc.system = "1";
                    //bdbankdoc.trantype = "code";

                    //post data
                    string bodyParams = JsonHelper.ToJson(bdbankdoc);
                    LogHelper.Default.WriteInfo(bodyParams);
                    string strResult = HttpPostHelper.sendInsert(url, bodyParams, headerParams, method);
                    LogHelper.Default.WriteInfo(strResult);
                }
            }
            catch(Exception ex)
            {
                LogHelper.Default.WriteError("BdBankDocRepository", ex);
            }

            
        }
    }
}