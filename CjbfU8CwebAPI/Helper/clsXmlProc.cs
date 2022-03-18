using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace CjbfU8CwebAPI.Helper
{
    public class clsXmlProc
    {
        

        public static void setXml(string billID,DateTime dt)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //bool bResult = false;
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "Helper\\XmlProc.xml");  

            XmlElement xe = xmlDoc.CreateElement("bill");
            XmlAttribute billIDx = xmlDoc.CreateAttribute("billID");
            billIDx.Value = billID;
            xe.Attributes.Append(billIDx);

            XmlAttribute result = xmlDoc.CreateAttribute("result");
            result.Value = "1";
            xe.Attributes.Append(result);

            XmlAttribute datetime = xmlDoc.CreateAttribute("datetime");
            datetime.Value = dt.ToString("yyyy-MM-dd HH:mm:ss");
            xe.Attributes.Append(datetime);

            xmlDoc.SelectSingleNode("ufinterface/u8capi").AppendChild(xe);
            xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "Helper\\XmlProc.xml");            
        }

        public static bool getXml(string billID)
        {
            XmlDocument xmlDoc = new XmlDocument();
            bool bResult = true ;
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "Helper\\XmlProc.xml");
            XmlNodeList xnl = xmlDoc.SelectNodes("ufinterface/u8capi/bill[@billID='" + billID + "']");
            if (xnl != null)
            {
                foreach(XmlNode xn in xnl)
                {
                    DateTime dt = Convert.ToDateTime(xn.Attributes["datetime"].Value);
                    if (DateTime.Now < dt)
                    {
                        bResult = false;
                        break;
                    }
                }
            }
            return bResult;
        }
    }
}