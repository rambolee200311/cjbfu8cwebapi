using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CjbfU8CwebAPI.Models.PAY
{
    public class Pay//付款申请单
    {
        /*
            billId  PM单据id
            billModuleCode PM单据模块code
            ccode	付款单编码
            ddate	申请日期
            ccusname	供应商名称
            cbank	开户银行
            cbankcode	行号
            caccount	银行账号
            cprojectcode	编制机构编码
            cprojectname	编制机构名称
            ccosttype	付款类型
            cperson	经办人
            csettletype	结算方式
            famount	申请金额
            cmemo	备注
            taxAmount 税额
            expAccode 费用会计科目
         */
        public string billId { get; set; }//PM单据id
        public string billModuleCode { get; set; }//PM单据模块code
        public string ccode { get; set; }//付款单编码
        public DateTime ddate { get; set; }//申请日期
        public string cbank { get; set; }//开户银行
        public string cbankcode { get; set; }//行号
        public string caccount { get; set; }//银行账号
        public string cprojectcode { get; set; }//编制机构编码
        public string cprojectname { get; set; }//编制机构名称
        public string ccosttype { get; set; }//付款类型
        public string cperson { get; set; }//经办人
        public string csettletype { get; set; }//结算方式
        public decimal famount { get; set; }//申请金额
        public string cmemo { get; set; }//备注
        public string ccusname { get; set; }//客商名称
        public decimal taxAmount { get; set; }//税额
         public string expAccode { get; set; }//费用会计科目
    }
}