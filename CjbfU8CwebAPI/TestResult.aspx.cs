using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Net;
using System.IO;
using CjbfU8CwebAPI.Helper;

namespace CjbfU8CwebAPI
{
    public partial class TestResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "Helper\\returnResult.xml");
            //ConnectToServer
            Response.Write(ConnectToServer(xmlDoc.SelectSingleNode("gepsInterface").OuterXml));
        }

        public string ConnectToServer(string strData)
        {
            string billType = "FKSQD";
            string opType = "Edit";
            string key = "123qwe)(*&^54321";
            string postData = string.Format("billType={0}&opType={1}&key={2}&strData={3}", billType, opType, key, strData);
            string serverPage = "http://pm.bucnc.com:8888/GEPS/Integration/CW/WebService/IntegrateService.asmx/Integrate";
            byte[] dataArray = Encoding.Default.GetBytes(postData);
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
                return null;//连接服务器失败
            }
            return res;
        }
    }
}