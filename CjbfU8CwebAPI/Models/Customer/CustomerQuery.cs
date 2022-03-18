using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;
using CjbfU8CwebAPI;
using CjbfU8CwebAPI.Models;
using CjbfU8CwebAPI.Helper;

namespace CjbfU8CwebAPI.Models.Customer
{
    public class CustomerQuery
    {
        string url = "https://api.yonyoucloud.com/apis/u8c/uapbd/custdoc_query";//请求接口地址
        string method = "POST";
        string apicode = "fe0f18f081a347e6a414011765ce0d91"; //配置您申请的appkey

        public string GetCustomer(string cusname)
        {
            //query body
            string strResult = "";
            var bodyParams = new Dictionary<string, string>();
            bodyParams.Add("pk_areacl", "");
            bodyParams.Add("startCreatetime", "");
            bodyParams.Add("endTs", "");
            bodyParams.Add("taxpayer", "");
            bodyParams.Add("page_now", "");
            bodyParams.Add("startTs", "");
            bodyParams.Add("custcode", "");
            bodyParams.Add("endCreatetime", "");
            bodyParams.Add("custname", cusname);
            bodyParams.Add("custshortname", "");
            bodyParams.Add("page_size", "");

            //query head
            var headerParams = new Dictionary<string, string>();
            headerParams.Add("apicode", apicode);
            headerParams.Add("system", "1");
            //headerParams.Add("Content-Type", "application/json");

            try
            {
                strResult = HttpPostHelper.sendQuery(url, bodyParams, headerParams, method);
                
                Cust_query_result cqr = JsonHelper.FromJson<Cust_query_result>(strResult);
                if (cqr.status == "success")
                {
                    strResult = "";
                    Cust_query_data cqd = JsonHelper.FromJson<Cust_query_data>(cqr.data);
                    if (cqd.allcount > 0)
                    {                        
                        foreach (Cust_query_data_detail cqdd in cqd.datas)
                        {
                            if (cusname == cqdd.parentvo.custname)
                            {
                                return strResult = cqdd.parentvo.custcode;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                strResult = ex.Message;
            }
            return strResult;
        }
    }
}