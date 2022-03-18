using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentScheduler;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Net;
using CjbfU8CwebAPI.Helper;
using CjbfU8CwebAPI.Models.PAY;
namespace CjbfU8CwebAPI.Scheduler
{
    public class MyJob:IJob
    {
        void IJob.Execute()
        {
            
            try
            {
                /*
                    parentvo.zyx1 = item.ccode;
                    parentvo.zyx2 = item.billModuleCode;
                    parentvo.zyx3 = item.billId; 
                 */
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "Helper/BaseData.xml");

                
                string strSql = "";

                string start_paydate = Convert.ToDateTime(xmlDoc.SelectSingleNode("ufinterface/start_paydate").InnerText).ToShortDateString();
                strSql = "select dr,djbh,djrq,shrq,spzt,paydate,zzzt,bbje,isnull(zyx1,'') zyx1,isnull(zyx2,'') zyx2,isnull(zyx3,'') zyx3,zyx4,zyx5,zyx6,zyx7,'1' result from cmp_busibill where zzzt=1 and djdl='fj' and djlxbm='D5' and paydate>=convert(datetime,'" + start_paydate + "') and isnull(zyx2,'')!='' and isnull(zyx3,'')!=''"
                    +" union all "
                    + "select dr,djbh,djrq,shrq,spzt,isnull(paydate,djrq),zzzt,bbje,isnull(zyx1,'') zyx1,isnull(zyx2,'') zyx2,isnull(zyx3,'') zyx3,zyx4,zyx5,zyx6,zyx7,'0' result from cmp_busibill where zzzt=0 and dr=1 and djdl='fj' and djlxbm='D5' and isnull(paydate,djrq)>=convert(datetime,'" + start_paydate + "') and isnull(zyx2,'')!='' and isnull(zyx3,'')!=''";
                DataTable dtable = DataHelper.getDataTableFromSql(strSql);
                //LogHelper.Default.WriteInfo(strSql);
                SetJob(dtable, "1");

                XmlDocument xmlDocSpecial = new XmlDocument();
                xmlDocSpecial.Load(AppDomain.CurrentDomain.BaseDirectory + "Helper/BaseDataSpecial.xml");
                DataTable dtableSpecial = dtable.Clone();
                foreach (XmlNode xn in xmlDocSpecial.SelectSingleNode("ufinterface").ChildNodes)
                {
                    DataRow[] rows = dtable.Select("zyx1='"+xn.InnerText+"'");
                    foreach(DataRow drow in rows)
                    {
                        DataRow dnew = dtableSpecial.NewRow();
                        foreach(DataColumn dc in dtableSpecial.Columns)
                        {
                            dnew[dc.ColumnName] = drow[dc.ColumnName];
                        }
                        dtableSpecial.Rows.Add(dnew);
                    }
                }
                SetJob(dtableSpecial, "2");
            }
            catch(Exception ex)
            {
                LogHelper.Default.WriteInfo(ex.Message);
            }
            finally
            {
                
            }
        }

        public string CmpObjToXml(gepsInterface gi)//put cmpBusBill
        {
            string strResult = "";
            //XmlDocument document = new XmlDocument();
            StringBuilder sb = new StringBuilder();    
            try
            {
                using (TextWriter tw = new StringWriter(sb))
                {
                    var xmlS = new XmlSerializer(typeof(gepsInterface));
                    xmlS.Serialize(tw, gi);
                    string serialized = sb.ToString();
                    serialized = serialized.Replace(@"xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""", "");
                    serialized = serialized.Replace(@"xmlns:xsd=""http://www.w3.org/2001/XMLSchema""", "");
                    //document.LoadXml(serialized);
                    strResult = serialized;
                    //LogHelper.Default.WriteInfo(strResult);
                }
                              
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
                LogHelper.Default.WriteInfo(ex.Message);
            }
            return strResult;
        }

        public string ConnectToServer( string strData)
        {
            string billType="FKSQD";
            string opType="Edit";
            string key = "123qwe)(*&^54321"; 
            string postData = string.Format("billType={0}&opType={1}&key={2}&strData={3}", billType, opType, key, strData);
            LogHelper.Default.WriteInfo(postData);
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
                LogHelper.Default.WriteInfo(res);
            }
            catch (Exception ex)
            {
                LogHelper.Default.WriteInfo(ex.Message);
                return null;//连接服务器失败
            }
            return res;
        }
    
        public void SetJob(DataTable dtable,string type)//type-1 classic type-2 special
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "Helper/BaseData.xml");
            XmlDocument xmlResult = new XmlDocument();
            if (dtable != null)
            {
                //Result re 
                Result re = new Result();
                gepsInterface gi = new gepsInterface();
                Voucher voucher = new Voucher();
                foreach (DataRow drow in dtable.Rows)
                {
                    //LogHelper.Default.WriteInfo("DataRow-zyx3:" + drow["zyx3"].ToString());
                    //if (xmlDoc.SelectSingleNode("ufinterface/cmp_busibill/bill[@billID='" + drow["zyx3"].ToString() + "' and @billModuleCode='" + drow["zyx2"].ToString() + "' and @resultCode='1']") == null)
                    if (((xmlDoc.SelectSingleNode("ufinterface/cmp_busibill/bill[@billID='" + drow["zyx3"].ToString() + "-" + drow["djbh"].ToString() 
                        + "' and @billModuleCode='" + drow["zyx2"].ToString() 
                        + "' and @resultCode='" + drow["result"].ToString() + "']") == null)&&
                        (type=="1"))
                        ||(type=="2"))
                    {
                        voucher.billID = drow["zyx3"].ToString();
                        //LogHelper.Default.WriteInfo("voucher.billID:" + drow["zyx3"].ToString());
                        //LogHelper.Default.WriteInfo("djbh:" + drow["djbh"].ToString());
                        voucher.billModuleCode = drow["zyx2"].ToString();

                        voucher.YWRQ = Convert.ToDateTime(drow["paydate"]);
                        voucher.syncTime = DateTime.Now;// Convert.ToDateTime(drow["paydate"]);

                        voucher.JE = Convert.ToDecimal(drow["bbje"].ToString());
                        voucher.syncState = "pay";

                        if (drow["zzzt"].ToString() == "1")
                        {
                            voucher.result = "1";
                            voucher.remark = "支付成功";
                        }
                        else if ((drow["zzzt"].ToString() == "0") && (drow["dr"].ToString() == "1"))//删除
                        {
                            voucher.result = "0";
                            voucher.remark = "支付失败";
                        }
                        gi.voucher = voucher;
                        re.GepsInterface = gi;
                        //LogHelper.Default.WriteInfo(CmpObjToXml(gi));
                        // 延迟5秒
                        Thread.Sleep(5000);

                        string strReult = ConnectToServer(CmpObjToXml(gi));
                        xmlResult.LoadXml(strReult);
                        if (xmlResult.SelectSingleNode("gepsInterface/sendResult").Attributes["resultCode"] != null)
                        {
                            if (xmlResult.SelectSingleNode("gepsInterface/sendResult").Attributes["resultCode"].Value.ToString() == "1")
                            {
                                XmlNode xmlnode = xmlDoc.SelectSingleNode("ufinterface/cmp_busibill/bill[@billID='' and @billModuleCode='']").Clone();
                                xmlnode.Attributes["billID"].Value = drow["zyx3"].ToString() + "-" + drow["djbh"].ToString();
                                xmlnode.Attributes["billModuleCode"].Value = drow["zyx2"].ToString();
                                xmlnode.Attributes["resultCode"].Value = voucher.result;
                                xmlnode.Attributes["datetime"].Value = DateTime.Now.ToString();
                                xmlnode.Attributes["djbh"].Value = drow["djbh"].ToString();
                                xmlDoc.SelectSingleNode("ufinterface/cmp_busibill").AppendChild(xmlnode);
                            }
                            else
                            {
                                XmlNode xmlnode = xmlDoc.SelectSingleNode("ufinterface/cmp_busibill/bill[@billID='' and @billModuleCode='']").Clone();
                                xmlnode.Attributes["billID"].Value = drow["zyx3"].ToString() + "-" + drow["djbh"].ToString();
                                xmlnode.Attributes["billModuleCode"].Value = drow["zyx2"].ToString();
                                xmlnode.Attributes["resultCode"].Value = xmlResult.SelectSingleNode("gepsInterface/sendResult").Attributes["resultCode"].Value.ToString();// voucher.result;
                                if (xmlResult.SelectSingleNode("gepsInterface/sendResult").Attributes["resultMsg"] != null)
                                {
                                    xmlnode.Attributes["resultMsg"].Value = xmlResult.SelectSingleNode("gepsInterface/sendResult").Attributes["resultMsg"].Value;
                                }
                                xmlnode.Attributes["datetime"].Value = DateTime.Now.ToString();
                                xmlnode.Attributes["djbh"].Value = drow["djbh"].ToString();
                                xmlDoc.SelectSingleNode("ufinterface/cmp_busibill").AppendChild(xmlnode);
                            }
                        }
                        //LogHelper.Default.WriteInfo(strReult);
                    }

                }
                //xmlDoc.SelectSingleNode("ufinterface/start_paydate").InnerText = DateTime.Now.ToShortDateString();
                xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "Helper/BaseData.xml");
            }
        }
    }
}