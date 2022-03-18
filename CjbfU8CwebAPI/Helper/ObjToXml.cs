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
using CjbfU8CwebAPI.Models.CMP;
using CjbfU8CwebAPI.Models.BD;
using CjbfU8CwebAPI.Models.CBA;
using System.Configuration;
namespace CjbfU8CwebAPI.Helper
{
    public static class ObjToXml
    {
        public static string CmpObjToXml(CmpBusBill cbb,string fileName)//put cmpBusBill
        {
            fileName =AppDomain.CurrentDomain.BaseDirectory+ "temp\\" + fileName;
            string strResult = "";
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CjbfU8CwebAPI.Models.CMP.Ufinterface));
                FileStream fs = new FileStream(fileName, FileMode.Create);
                TextWriter writer = new StreamWriter(fs, new UTF8Encoding());
                serializer.Serialize(writer, cbb.ufinterface);
                writer.Close();

                strResult = putToU8CEAI(fileName);
            }
            catch(Exception ex)
            {
                strResult = ex.Message;
            }
            return strResult;
        }
        public static string CmpObjToXml(Bscubas cbb, string fileName)//put cmpBusBill
        {
            fileName = AppDomain.CurrentDomain.BaseDirectory+ "temp\\" + fileName;
            string strResult = "";
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CjbfU8CwebAPI.Models.BD.Ufinterface));
                FileStream fs = new FileStream(fileName, FileMode.Create);
                TextWriter writer = new StreamWriter(fs, new UTF8Encoding());
                serializer.Serialize(writer, cbb.ufinterface);
                writer.Close();

                strResult = putToU8CEAI(fileName);
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
            }
            return strResult;
        }
        public static string CmpObjToXml(CusBankAccount cbb, string fileName)//put cmpBusBill
        {
            fileName = AppDomain.CurrentDomain.BaseDirectory+ "temp\\" + fileName;
            string strResult = "";
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CjbfU8CwebAPI.Models.CBA.Ufinterface));
                FileStream fs = new FileStream(fileName, FileMode.Create);
                TextWriter writer = new StreamWriter(fs, new UTF8Encoding());
                serializer.Serialize(writer, cbb.ufinterface);
                writer.Close();

                strResult = putToU8CEAI(fileName);
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
                LogHelper.Default.WriteError("ObjToXml_CmpObjToXml", ex);
            }
            return strResult;
        }
        public static string putToU8CEAI(string fileName)//请求TTX接口API代码
        {
            string backstr = "";
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                Encoding myEncoding = Encoding.GetEncoding("UTF-8");
                byte[] requestBytes = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(xmlDoc.OuterXml);
                //http://39.105.145.185:8090
                string strUrl = "http://39.105.145.185:8090/service/XChangeServlet?";
                if (fileName.IndexOf("bscubas_")==0)
                { strUrl += "account=U8cloud&receiver=0001"; }
                else
                { strUrl += "account=U8cloud&receiver=001001"; }

                strUrl+="&token=" + GetToken();
                LogHelper.Default.WriteInfo(strUrl);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strUrl);
                
                req.Method = "POST";
                req.ContentType = "text/xml";
                req.ContentLength = requestBytes.Length;
                Stream requestStream = req.GetRequestStream();
                requestStream.Write(requestBytes, 0, requestBytes.Length);
                requestStream.Close();
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream(), myEncoding);
                backstr = sr.ReadToEnd();
                sr.Close();
                res.Close();

            }
            catch (Exception ex)
            {
                //
                backstr = "[" + ex.Source + "]" + ex.Message;
                LogHelper.Default.WriteError("ObjToXml_putToU8CEAI", ex);
            }
            finally
            {
                //
            }
            return backstr;
        }
        public static string GetToken()//请求TTX接口API代码
        {
            string backstr = "";
            try
            {
                string U8CloudUrl = ConfigurationManager.ConnectionStrings["U8CloudUrl"].ConnectionString;
                string usercode = ConfigurationManager.ConnectionStrings["usercode"].ConnectionString;
                string md5pwd = ConfigurationManager.ConnectionStrings["md5pwd"].ConnectionString;
                string shapwd = ConfigurationManager.ConnectionStrings["shapwd"].ConnectionString;
                Encoding myEncoding = Encoding.GetEncoding("UTF-8");
                string strUrl = U8CloudUrl+"?usercode="+usercode+"&md5pwd="+md5pwd+"&shapwd="+shapwd;
                LogHelper.Default.WriteInfo(strUrl);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strUrl);
                req.Method = "POST";
                req.ContentType = "text/xml";
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream(), myEncoding);
                backstr = sr.ReadToEnd();
                sr.Close();
                res.Close();
            }
            catch (Exception ex)
            {
                //
                backstr = "[" + ex.Source + "]" + ex.Message;
                LogHelper.Default.WriteError("ObjToXml_putToU8CEAI", ex);
            }
            finally
            {
                //
            }
            return backstr;
        }
    }
}