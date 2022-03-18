using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CjbfU8CwebAPI.Models;
using System.Xml;
using CjbfU8CwebAPI.Helper;
using CjbfU8CwebAPI.Models.PAY;
using CjbfU8CwebAPI.Models.FJ;

namespace CjbfU8CwebAPI.Helper
{
    public static class ResultProc
    {
        public static void ResultVoucherProc(Voucher voucher,string strResult)//返回结果处理
        {
            string cResult = "0";
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strResult.Replace("\r","").Replace("\n",""));
                cResult = xmlDoc.SelectSingleNode(@"ufinterface/sendresult/resultcode").InnerText;
                if (cResult == "1")
                {
                    voucher.result = "1";
                    voucher.remark = "同步成功！";
                }
                else
                {
                    voucher.result = "0";
                    voucher.remark = xmlDoc.SelectSingleNode(@"ufinterface/sendresult/resultdescription").InnerText;
                }
            }
            catch(Exception EX)
            {
                voucher.result = "0";
                voucher.remark = EX.Message;
            }
        }

         public static void FjResultProc(Voucher voucher,string strResult,Pay item)
        {
             try
             {
                 Fj_insert_result fir =JsonHelper.FromJson<Fj_insert_result>(strResult) ;
                 if (fir.status == "falied")
                 {
                     voucher.result = "0";
                     voucher.remark = fir.errorcode+" "+fir.errormsg;
                 }
                 else if (fir.status == "success")
                 {
                     voucher.result = "1";
                     voucher.remark = "同步成功！";
                     voucher.JE = item.famount;
                     //CjbfU8CwebAPI.Models.Fj.Fj_bill fbill = JsonHelper.FromJson<CjbfU8CwebAPI.Models.Fj.Fj_bill>(fir.data);
                     
                 }

             }
             catch (Exception EX)
             {
                 voucher.result = "0";
                 voucher.remark = EX.Message;
             }
        }
    }
}