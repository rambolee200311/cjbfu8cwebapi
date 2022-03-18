using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CjbfU8CwebAPI.Models.Bank
{
    public class BankDoc
    {
        public string address { get; set; }// 地址
        public string amcode { get; set; }//助记码
        public string bankdoccode { get; set; }//银行档案编
        public string bankdocname { get; set; }//银行档案名
        public string banktypecode { get; set; }//银行类别编
        public string banktypename { get; set; }//银行类别名
        public string city { get; set; }//城市
        public string createtime { get; set; }//创建时间
        public string creator { get; set; }//创建人
        public string creatorcode { get; set; }//创建人编码
        public string creatorname { get; set; }//创建人姓名
        public string def1 { get; set; }//自定义项1
        public string def2 { get; set; }//自定义项2
        public string def3 { get; set; }//自定义项3
        public string def4 { get; set; }//自定义项4
        public string def5 { get; set; }//自定义项5
        public string dr { get; set; }//删除标志
        public string fatherbankcode { get; set; }//上级银行编
        public string fatherbankname { get; set; }//上级银行名
        public string iscustbank { get; set; }//客商银行
        public string linkman1 { get; set; }//联系人1
        public string linkman2 { get; set; }//联系人2
        public string linkman3 { get; set; }//联系人3
        public string modifier { get; set; }//修改人
        public string modifiercode { get; set; }//修改人编码
        public string modifiername { get; set; }//修改人姓名
        public string pcombinename { get; set; }//人行联行名
        public string pcombinenum { get; set; }//人行联行号
        public string phone1 { get; set; }//联系电话1
        public string phone2 { get; set; }//联系电话2
        public string phone3 { get; set; }//联系电话3
        public string pk_bankdoc { get; set; }//银行档案主
        public string pk_banktype { get; set; }//银行类别主
        public string pk_corp { get; set; }//公司主键
        public string pk_fatherbank { get; set; }//上级银行主
        public string pk_pcombine { get; set; }//人行联行信
        public string pk_settlecenter { get; set; }//资金组织
        public string province { get; set; }//省
        public string sealflag { get; set; }//封存标记
        public string settlecentercode { get; set; }//资金组织编
        public string settlecentername { get; set; }//资金组织名
        public string shortname { get; set; }//简称
        public string swiftnum { get; set; }//swift
        public string ts { get; set; }//时间戳
        public string unitcode { get; set; }//公司编码
        public string unitname { get; set; }//公司名称
    }
}