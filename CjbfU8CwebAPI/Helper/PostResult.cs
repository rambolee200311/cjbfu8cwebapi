using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CjbfU8CwebAPI.Models;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Net;

namespace CjbfU8CwebAPI.Helper
{
    public class PostResult
    {
        public static string putToU8CEAI(string fileName)//请求TTX接口API代码
        {
            string backstr = "";
            try
            {
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(fileName);
                //Encoding myEncoding = Encoding.GetEncoding("UTF-8");
                //byte[] requestBytes = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(xmlDoc.OuterXml);
                //string strUrl = "http://182.48.117.56:8888/GEPS/Integration/CW/WebService/IntegrateService.asmx?billType=FKSQD&opType=EDIT&key=123qwe)(*&^54321";
                //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strUrl);

                //req.Method = "POST";
                //req.ContentType = "text/xml";
                //req.ContentLength = requestBytes.Length;
                //Stream requestStream = req.GetRequestStream();
                //requestStream.Write(requestBytes, 0, requestBytes.Length);
                //requestStream.Close();
                //HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                //StreamReader sr = new StreamReader(res.GetResponseStream(), myEncoding);
                //backstr = sr.ReadToEnd();
                //sr.Close();
                //res.Close();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                //xmlDoc.SelectSingleNode("gepsInterface/voucher/syncTime").InnerText = DateTime.Now.ToString();
                //GEPSWebService.IntegrateService geps = new GEPSWebService.IntegrateService();
                //XmlNode xn = ("FKSQD", "EDIT", "123qwe)(*&^54321", xmlDoc.OuterXml);
                backstr = ConnectToServer("http://182.48.117.56:8888/GEPS/Integration/CW/WebService/IntegrateService.asmx/Integrate", "FKSQD", "Edit", "123qwe)(*&^54321", xmlDoc.OuterXml);

            }
            catch (Exception e)
            {
                //
                backstr = "[" + e.Source + "]" + e.Message;
            }
            finally
            {
                //
            }
            return backstr;
        }

        public static string ConnectToServer(string serverPage, string billType, string opType, string key, string strData)
        {
            string postData = string.Format("billType={0}&opType={1}&key={2}&strData={3}", billType, opType, key, strData);

            byte[] dataArray = Encoding.GetEncoding("UTF-8").GetBytes(postData);
            //创建请求
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(serverPage);
            request.Method = "POST";
            request.ContentLength = dataArray.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            //创建输入流
            Stream dataStream = null;
            try
            {
                dataStream = request.GetRequestStream();
            }
            catch (Exception)
            {
                return null;//连接服务器失败
            }

            //发送请求
            dataStream.Write(dataArray, 0, dataArray.Length);
            dataStream.Close();
            //读取返回消息
            string res = string.Empty;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    res = reader.ReadToEnd();
                    reader.Close();
                }
                
            }
            catch (Exception ex)
            {
                LogHelper.Default.WriteError("httppost error:",ex);
                return null;//连接服务器失败
            }
            LogHelper.Default.WriteInfo(res);
            return res;
        }
    }
}