using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Diagnostics;
namespace CjbfU8CwebAPI.Helper
{
    public class HttpPostHelper
    {

        public static string sendInsert(string url, string bodyParams, IDictionary<string, string> headerParams, string method)
        {
            string strResult = "";
            try
            {
                HttpWebRequest req = null;
                HttpWebResponse rsp = null;
                System.IO.Stream reqStream = null;
                
                req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = method;
                req.KeepAlive = false;
                req.ProtocolVersion = HttpVersion.Version10;
                req.Timeout = 5000;
                req.ContentType = "application/json;charset=utf-8";
                BuildHeader(headerParams, req);
                //var json = Newtonsoft.Json.JsonConvert.SerializeObject(bodyParams);
                byte[] postData = Encoding.UTF8.GetBytes(bodyParams);
                reqStream = req.GetRequestStream();
                reqStream.Write(postData, 0, postData.Length);
                rsp = (HttpWebResponse)req.GetResponse();
                Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
                strResult=GetResponseAsString(rsp, encoding);
            }
            catch(Exception ex)
            {
                strResult = ex.Message;
            }
            return strResult;
        }
        public static string sendQuery(string url, IDictionary<string, string> bodyParams, IDictionary<string, string> headerParams, string method)
        {
            string strResult = "";
            if (method.ToLower() == "post")
            {
                HttpWebRequest req = null;
                HttpWebResponse rsp = null;
                System.IO.Stream reqStream = null;
                try
                {
                    req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = method;
                    req.KeepAlive = false;
                    req.ProtocolVersion = HttpVersion.Version10;
                    req.Timeout = 5000;
                    req.ContentType = "application/json;charset=utf-8";
                    BuildHeader(headerParams, req);
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(bodyParams);
                    byte[] postData = Encoding.UTF8.GetBytes(json);
                    reqStream = req.GetRequestStream();
                    reqStream.Write(postData, 0, postData.Length);
                    rsp = (HttpWebResponse)req.GetResponse();
                    Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
                    strResult=GetResponseAsString(rsp, encoding);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (reqStream != null) reqStream.Close();
                    if (rsp != null) rsp.Close();
                }
                return strResult;
            }
            else
            {
                //创建请��
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + BuildQuery(bodyParams, "utf8"));

                //GET请求
                request.Method = "GET";
                request.ReadWriteTimeout = 5000;
                request.ContentType = "text/html;charset=UTF-8";
                BuildHeader(headerParams,request);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

                //返回内容
                string retString = myStreamReader.ReadToEnd();
                return retString;
            }
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        static string BuildQuery(IDictionary<string, string> parameters, string encode)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;
            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name))//&& !string.IsNullOrEmpty(value)
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }
                    postData.Append(name);
                    postData.Append("=");
                    if (encode == "gb2312")
                    {
                        postData.Append(HttpUtility.UrlEncode(value, Encoding.GetEncoding("gb2312")));
                    }
                    else if (encode == "utf8")
                    {
                        postData.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
                    }
                    else
                    {
                        postData.Append(value);
                    }
                    hasParam = true;
                }
            }
            return postData.ToString();
        }

        /// <summary>
        /// 组装请求头参数。
        /// </summary>
        /// <param name="headerParams">Key-Value形式请求参数字典</param>
        /// <param name="req">web请求</param>
        static void BuildHeader(IDictionary<string, string> headerParams, HttpWebRequest req)
        {
            try 
            { 
                IEnumerator<KeyValuePair<string, string>> dem = headerParams.GetEnumerator();
                while (dem.MoveNext())
                {
                    req.Headers.Add(dem.Current.Key,dem.Current.Value);
                }
            }
            catch (Exception ex)
            {
                req.Headers.Add(ex.Source, ex.Message);
            }

        }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        static string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            System.IO.Stream stream = null;
            StreamReader reader = null;
            string strResult = "";
            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                strResult=reader.ReadToEnd();
            }
                catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
                
            }
            return strResult;
        }
    }
}