using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace CjbfU8CwebAPI.Models.CBA
{
    public class CusBankAccount
    {
        public Ufinterface ufinterface { get; set; }
    }
    public class Ufinterface
    {
        //<ufinterface roottag="basdoc" billtype="bankaccount" replace="Y" receiver="0001" sender="1101" isexchange="Y" filename="银行账户数据文件.xml" proc="add">
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
        //<!--账户属性,最大长度为2,类型为:Integer-->
        //    <accattribute></accattribute>
        public string accattribute{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--账户分类,最大长度为2,类型为:Integer-->
            //<accclass>1</accclass>
        public string accclass{get;set;}
            //<!--开户日期,最大长度为10,类型为:Date-->
            //<accopendate>2008-10-29</accopendate>
        public string accopendate{get;set;}
            //<!--账号,不能为空,最大长度为100,类型为:String-->
            //<account>account</account>
        public string account{get;set;}
            //<!--账户编码,不能为空,最大长度为40,类型为:String-->
            //<accountcode>account_code</accountcode>
        public string accountcode{get;set;}
            //<!--账户名称,不能为空,最大长度为200,类型为:String-->
            //<accountname>account_name</accountname>
        public string accountname{ get; set; }
            //<!--账户性质,最大长度为2,类型为:Integer-->
            //<accountproperty>0</accountproperty>
        public string accountproperty{get;set;}
            //<!--账户状态,最大长度为2,类型为:Integer-->
            //<accstate>0</accstate>
        public string accstate{get;set;}
            //<!--账户类型,不能为空,最大长度为2,类型为:Integer-->
            //<acctype>0</acctype>
        public string acctype{get;set;}
            //<!--销户日期,最大长度为10,类型为:Date-->
            //<accxhdate></accxhdate>
        public string accxhdate{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--收付属性,最大长度为2,类型为:Integer-->
            //<arapprop>2</arapprop>
        public string arapprop {get;set;}
            //<!--地区代码,最大长度为28,类型为:String-->
            //<areacode>1001</areacode>
        public string areacode{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--开户地区,最大长度为80,类型为:String-->
            //<bankarea></bankarea>
        public string bankarea{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--城市,最大长度为80,类型为:String-->
            //<city></city>
        public string city{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--联行号,最大长度为80,类型为:String-->
            //<combineaccnum></combineaccnum>
            public string combineaccnum{get;set;}
            //<!--协定金额,最大长度为16,类型为:Double-->
            //<concertedmny></concertedmny>
         public string concertedmny{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--联系人,最大长度为25,类型为:String-->
            //<contactpsn></contactpsn>
             public string contactpsn{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--对应总账户,最大长度为20,类型为:String-->
            //<corrgeneaccount></corrgeneaccount>
        public string corrgeneaccount{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--创建时间,最大长度为19,类型为:String-->
            //<createtime></createtime>
        public string createtime{get;set;}
            //<!--创建人,最大长度为20,类型为:String-->
            //<creator></creator>
        public string creator{get;set;}
            //<!--客户编码,最大长度为40,类型为:String-->
            //<custcode></custcode>
        public string custcode{get;set;}
            //<!--自定义项1,最大长度为100,类型为:String-->
            //<def1></def1>
            //<!--自定义项10,最大长度为100,类型为:String-->
            //<def10></def10>
            //<!--自定义项11,最大长度为100,类型为:String-->
            //<def11></def11>
            //<!--自定义项12,最大长度为100,类型为:String-->
            //<def12></def12>
            //<!--自定义项13,最大长度为100,类型为:String-->
            //<def13></def13>
            //<!--自定义项14,最大长度为100,类型为:String-->
            //<def14></def14>
            //<!--自定义项15,最大长度为100,类型为:String-->
            //<def15></def15>
            //<!--自定义项16,最大长度为100,类型为:String-->
            //<def16></def16>
            //<!--自定义项17,最大长度为100,类型为:String-->
            //<def17></def17>
            //<!--自定义项18,最大长度为100,类型为:String-->
            //<def18></def18>
            //<!--自定义项19,最大长度为100,类型为:String-->
            //<def19></def19>
            //<!--自定义项2,最大长度为100,类型为:String-->
            //<def2></def2>
            //<!--自定义项20,最大长度为100,类型为:String-->
            //<def20></def20>
            //<!--自定义项3,最大长度为100,类型为:String-->
            //<def3></def3>
            //<!--自定义项4,最大长度为100,类型为:String-->
            //<def4></def4>
            //<!--自定义项5,最大长度为100,类型为:String-->
            //<def5></def5>
            //<!--自定义项6,最大长度为100,类型为:String-->
            //<def6></def6>
            //<!--自定义项7,最大长度为100,类型为:String-->
            //<def7></def7>
            //<!--自定义项8,最大长度为100,类型为:String-->
            //<def8></def8>
            //<!--自定义项9,最大长度为100,类型为:String-->
            //<def9></def9>
        public string def1{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def2{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def3{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def4{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def5{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def6{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def9{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def7{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def8{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def10{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def11{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def12{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def13{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def14{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def15{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def16{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def19{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def17{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def18{get{return _defaultValue;}set{value=_defaultValue;}}
        public string def20{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--解冻日期,最大长度为10,类型为:Date-->
            //<defrozendate></defrozendate>
        public string defrozendate{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--冻结日期,最大长度为10,类型为:Date-->
            //<frozendate></frozendate>
        public string frozendate{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--冻结金额,最大长度为16,类型为:Double-->
            //<frozenje></frozenje>
        public string frozenje{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--资金形态,最大长度为2,类型为:Integer-->
            //<fundform>1</fundform>
        public string fundform{get;set;}
            //<!--总分属性,最大长度为2,类型为:Integer-->
            //<genebranprop>2</genebranprop>
        public string genebranprop{get;set;}
            //<!--集团账户,最大长度为1,类型为:Boolean-->
            //<groupaccount>N</groupaccount>
        public string groupaccount{get;set;}
            //<!--集团号,最大长度为20,类型为:String-->
            //<groupid></groupid>
        public string groupid{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--是否内部账户,最大长度为1,类型为:Boolean-->
            //<isinneracc>N</isinneracc>
        public string isinneracc{get;set;}
            //<!--对应银行账号,最大长度为20,类型为:String-->
            //<mainaccount></mainaccount>
        public string mainaccount{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--备注,最大长度为100,类型为:String-->
            //<memo></memo>
        public string memo{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--修改人,最大长度为20,类型为:String-->
            //<modifier></modifier>
        public string modifier{get{return _defaultValue;}set{value=_defaultValue;}}
            //<!--修改时间,最大长度为19,类型为:String-->
            //<modifytime></modifytime>
        public string modifytime { get { return _defaultValue; } set { value = _defaultValue; } }
            //<!--网银开通状态,最大长度为2,类型为:Integer-->
            //<netqueryflag>0</netqueryflag>
        public string netqueryflag {get;set;}
            //<!--机构号,最大长度为80,类型为:String-->
            //<orgnumber></orgnumber>
        public string orgnumber { get { return _defaultValue; } set { value = _defaultValue; } }
            //<!--开户公司,不能为空,最大长度为4,类型为:String-->
            //<ownercorp>gs01</ownercorp>
        public string ownercorp { get; set; }
            //<!--银行账户基本信息主键,最大长度为20,类型为:String-->
            //<pk_bankaccbas></pk_bankaccbas>
        public string pk_bankaccbas { get;  set  ;  }
            //<!--开户银行,最大长度为20,类型为:String-->
            //<pk_bankdoc></pk_bankdoc>
        public string pk_bankdoc { get; set  ;  }
            //<!--银行类别,不能为空,最大长度为20,类型为:String-->
            //<pk_banktype>18</pk_banktype>
        public string pk_banktype{get;set;}
            //<!--公司主键,最大长度为4,类型为:String-->
            //<pk_corp>0001</pk_corp>
        public string pk_corp{get;set;}
            //<!--币种,不能为空,最大长度为20,类型为:String-->
            //<pk_currtype>CNY</pk_currtype>
        public string pk_currtype{get;set;}
            //<!--网银接口类别,最大长度为20,类型为:String-->
            //<pk_netbankinftp></pk_netbankinftp>
        public string pk_netbankinftp { get { return _defaultValue; } set { value = _defaultValue; } }
            //<!--备用金使用人,最大长度为20,类型为:String-->
            //<pk_psnbasdoc></pk_psnbasdoc>
        public string pk_psnbasdoc { get ; set  ; }
            //<!--省份,最大长度为80,类型为:String-->
            //<province></province>
        public string province { get { return _defaultValue; } set { value = _defaultValue; } }
            //<!--助记码,最大长度为50,类型为:String-->
            //<remcode></remcode>
        public string remcode { get { return _defaultValue; } set { value = _defaultValue; } }
            //<!--是否签约,最大长度为1,类型为:Boolean-->
            //<signflag>0</signflag>
        public string signflag{get;set;}
            //<!--联系电话,最大长度为30,类型为:String-->
            //<tel></tel>
        public string tel { get { return _defaultValue; } set { value = _defaultValue; } }
            //<!--单位名称,最大长度为100,类型为:String-->
            //<unitname></unitname>
        public string unitname{get;set;}
    }
}