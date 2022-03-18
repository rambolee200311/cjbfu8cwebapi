using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CjbfU8CwebAPI.Models.BD;
using CjbfU8CwebAPI.Models.CBA;
using CjbfU8CwebAPI.Helper;
using System.Xml;

namespace CjbfU8CwebAPI.Models.BD
{
    public class BscubasRepository
    {
        public static void BscubasProc(string cCusname, string cBank, string cBankCode, string cAccount)
        {
            try
            {
                
                //use model
                Bscubas bscubas = new Bscubas();
                Ufinterface ufinterface = new Ufinterface();
                Basdoc basdoc = new Basdoc();
                Basdoc_head basdoc_head = new Basdoc_head();

                //assgin values
                //<ufinterface roottag="basdoc" billtype="bscubas" replace="Y" receiver="0001" sender="1101" isexchange="Y" filename="客商档案样本数据文件.xml" proc="add">
                string Filename = "bscubas_";
                Filename += Guid.NewGuid();
                Filename += ".xml";
                string cCuscode = MyRandom.GetMyRandom();
                ufinterface.roottag = "basdoc";
                ufinterface.billtype = "bscubas";
                ufinterface.replace = "Y";
                ufinterface.receiver = "001001";
                ufinterface.sender = "gld";
                ufinterface.isexchange = "Y";
                ufinterface.filename = Filename;
                ufinterface.proc = "add";

                basdoc.id = cCuscode;

                //<!--公司，不能为空，需要对照基础数据（公司目录），集团填写0001-->
                //<pk_corp>0001</pk_corp>
                basdoc_head.pk_corp = "001001";
                //<!--地区分类,不能为空，需要对照基础数据（地区分类）-->
                //<pk_areacl>华北地区yk</pk_areacl>
                basdoc_head.pk_areacl = "广联达";
                //<!--客商编号，不能为空,不能重复-->
                //<custcode>yk</custcode>	
                basdoc_head.custcode = cCuscode;
                //<!--客商名称，不能为空,不能重复-->
                //<custname>公司yk</custname>
                basdoc_head.custname = cCusname;
                //<!--客商简称，不能为空,必须输入-->
                //<custshortname>公司yk</custshortname>
                basdoc_head.custshortname = cCusname;
                //<!--是否散户(不能为空,必须填写Y/N)，默认N-->
                //<freecustflag>N</freecustflag>
                basdoc_head.freecustflag = "N";
                //<!--是否DRP结点(不能为空，必须填写Y/N），默认N-->
                //<drpnodeflag>N</drpnodeflag>
                basdoc_head.drpnodeflag = "N";
                //<!--是否渠道成员(不能为空，必须填写,Y/N），默认N-->
                //<isconnflag>N</isconnflag>
                basdoc_head.isconnflag = "N";
                //<!--客商类型(不能为空，缺省为0, 0：外部单位 1：内部核算单位 2：内部法人单位 3：内部渠道成员)-->
                //<custprop>0</custprop>
                basdoc_head.custprop = "0";
                //<!--客商属性（只有“新增”时有效。不能为空，缺省为2，0：客户 1：供应商 2：客商）-->
                //<custtype>2</custtype>
                basdoc_head.custtype = "2";

                //put to EAI
                //basdoc.basdoc_head = basdoc_head;
                //ufinterface.basdoc = basdoc;
                //bscubas.ufinterface = ufinterface;
                //string strResult = ObjToXml.CmpObjToXml(bscubas, Filename);
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.LoadXml(strResult.Replace("\r", "").Replace("\n", ""));
                //xmlDoc.Save("d:\\temp\\result_" + Filename);

                //add cust bank account
                CusBankAccountRepository.BscubasProc(cCusname, cCuscode, cBank, cBankCode, cAccount, "busisness");
                
            }
            catch(Exception ex)
            {
                LogHelper.Default.WriteError("BscubasRepository",ex);
                //do nothing
            }
        }
    }
}