using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CjbfU8CwebAPI.Models.PAY
{
    public class Result
    {
        /*
         <gepsInterface>
                <voucher>
	                
                </voucher>
                </gepsInterface>
         */
        public gepsInterface GepsInterface{get;set;}
    }
    public class gepsInterface
    {
        public Voucher voucher { get; set; }
    }
    public class Voucher
    {
        //<!-- billId="PM单据id" -->
        //<billId>100987</billId>
        public string billID{get;set;}
        //<!-- billModuleCode="PM单据模块code" -->
        //<billModuleCode></billModuleCode>
        public string billModuleCode{get;set;}
        //<!-- YWRQ="付款时间" -->
        //<YWRQ>2019-8-26</YWRQ>
        public DateTime YWRQ{get;set;}
        //<!-- JE="支付金额" -->
        //<JE>1000</JE>
        public decimal JE{get;set;}
        //<!-- syncState="审批状态" -->
        //<syncState></syncState>
        public string syncState{get;set;}
        //<!-- syncTime="审批时间" -->
        //<syncTime>2019-8-26</syncTime>
        public DateTime syncTime{get;set;}
        //<!-- result="付款结果 true=已支付，false=支付失败" -->
        //<result>true/false</result>
        public string result{get;set;}
        //<!-- result="备注信息 审批不通过或支付失败等信息 true=已付款，false=未付款" -->
        //<remark></remark>
        public string remark { get; set; }
    }
}