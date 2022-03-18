using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace CjbfU8CwebAPI.Models.BD
{
    public class Bscubas
    {
        public Ufinterface ufinterface { get; set; }
    }
    public class Ufinterface
    {
        //<ufinterface roottag="basdoc" billtype="bscubas" replace="Y" receiver="0001" sender="1101" isexchange="Y" filename="客商档案样本数据文件.xml" proc="add">
        [XmlAttribute]
        public string roottag { get; set; }
        [XmlAttribute]
        public string billtype { get; set; }
        [XmlAttribute]
        public string replace { get; set; }
        [XmlAttribute]
        public string receiver { get; set; }
        [XmlAttribute]
        public string sender { get; set; }
        [XmlAttribute]
        public string isexchange { get; set; }
        [XmlAttribute]
        public string filename { get; set; }
        [XmlAttribute]
        public string proc { get; set; }
        public Basdoc basdoc { get; set; }
    }

    public class Basdoc
    {
        [XmlAttribute]
        public string id { get; set; }

        public Basdoc_head basdoc_head { get; set; }
    }
    public class Basdoc_head
    {
        private string _defaultValue="";
        //<!--客商基本档案主键,20位，可为空，由外系统指定或NC系统自动生成,要保证唯一-->
        //    <pk_cubasdoc></pk_cubasdoc>
			public string pk_cubasdoc{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--公司，不能为空，需要对照基础数据（公司目录），集团填写0001-->
            //<pk_corp>0001</pk_corp>
			public string pk_corp{get;set;}
            //<!--地区分类,不能为空，需要对照基础数据（地区分类）-->
            //<pk_areacl>华北地区yk</pk_areacl>
			public string pk_areacl{get;set;}
            //<!--对应公司编码,可以为空，需要对照基础数据（公司目录）-->
            //<pk_corp1></pk_corp1>
			public string pk_corp1{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--客商编号，不能为空,不能重复-->
            //<custcode>yk</custcode>	
			public string custcode{get;set;}
            //<!--客商名称，不能为空,不能重复-->
            //<custname>公司yk</custname>
			public string custname{get;set;}
            //<!--客商简称，不能为空,必须输入-->
            //<custshortname>公司yk</custshortname>
			public string custshortname{get;set;}
            //<!--外文名称，可以为空-->
            //<engname></engname>
			public string engname{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--助记码,可以为空-->
            //<mnecode></mnecode>
			public string mnecode{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--所属行业,可以为空，需要对照基础数据（经济行业）-->
            //<trade></trade>
			public string trade{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--是否散户(不能为空,必须填写Y/N)，默认N-->
            //<freecustflag>N</freecustflag>
			public string freecustflag{get;set;}
            //<!--是否DRP结点(不能为空，必须填写Y/N），默认N-->
            //<drpnodeflag>N</drpnodeflag>
			public string drpnodeflag{get;set;}
            //<!--是否渠道成员(不能为空，必须填写,Y/N），默认N-->
            //<isconnflag>N</isconnflag>
			public string isconnflag{get;set;}
            //<!--客商总公司编码,可以为空，需要对照基础数据（客商基本档案）-->
            //<pk_cubasdoc1></pk_cubasdoc1>
			public string pk_cubasdoc1{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--客商类型(不能为空，缺省为0, 0：外部单位 1：内部核算单位 2：内部法人单位 3：内部渠道成员)-->
            //<custprop>0</custprop>
            public string custprop{get;set;}            
            //<!--客商属性（只有“新增”时有效。不能为空，缺省为2，0：客户 1：供应商 2：客商）-->
            //<custtype>2</custtype>
			public string custtype{get;set;} 
            //<!--纳税人登记号，可以为空-->
            //<taxpayerid></taxpayerid>
			public string taxpayerid{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--法人，可以为空-->
            //<legalbody></legalbody>
			public string legalbody{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--信用额度, 可以为空-->
            //<creditmny></creditmny>
			public string creditmny{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--经济类型，可以为空，需要对照基础数据（经济类型）-->
            //<ecotype></ecotype>
			public string ecotype{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--营业地址，可以为空-->
            //<saleaddr></saleaddr>
			public string saleaddr{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--通信地址，可以为空-->
            //<conaddr></conaddr>
			public string conaddr{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--邮政编码，可以为空-->
            //<zipcode></zipcode>			
			public string zipcode{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--三个电话，可以为空-->
            //<phone1>62986688</phone1>
            //<phone2></phone2>
            //<phone3></phone3>
			public string phone1{get{return _defaultValue;}set{value=_defaultValue;}}
            public string phone2{get{return _defaultValue;}set{value=_defaultValue;}}
            public string phone3{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--两个传真，可以为空-->
            //<fax1></fax1>
            //<fax2></fax2>
			public string fax1{get{return _defaultValue;}set{value=_defaultValue;}}
            public string fax2{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--三个联系人，可以为空-->
            //<linkman1></linkman1>
            //<linkman2></linkman2>
            //<linkman3></linkman3>
			public string linkman1{get{return _defaultValue;}set{value=_defaultValue;}}
            public string linkman2{get{return _defaultValue;}set{value=_defaultValue;}}
            public string linkman3{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--三个呼机，可以为空-->
            //<bp1></bp1>
            //<bp2></bp2>
            //<bp3></bp3>
			public string bp1{get{return _defaultValue;}set{value=_defaultValue;}}
            public string bp2{get{return _defaultValue;}set{value=_defaultValue;}}
            public string bp3{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--三个手机，可以为空-->
            //<mobilephone1></mobilephone1>
            //<mobilephone2></mobilephone2>
            //<mobilephone3></mobilephone3>
			public string mobilephone1{get{return _defaultValue;}set{value=_defaultValue;}}
            public string mobilephone2{get{return _defaultValue;}set{value=_defaultValue;}}
            public string mobilephone3{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--E-mail地址，可以为空-->
            //<email></email>
			public string email{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--Web网址，可以为空-->
            //<url></url>
			public string url{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--注册资金，可以为空-->
            //<registerfund>0</registerfund>
            public string registerfund { get { return _defaultValue; } set { value = _defaultValue; } }
            //<!--备注，可以为空-->
            //<memo></memo>
            public string memo{ get { return _defaultValue; } set { value = _defaultValue; } }
    }
}