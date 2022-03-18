using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace CjbfU8CwebAPI.Models.CMP
{
    public class CmpBusBill
    {
        //<ufinterface roottag="voucher" billtype="D5" subtype="run" replace="Y"
        //receiver="19" sender="102" proc="add" isexchange="Y"
        //filename="付款结算单模板demo.xml">

        public Ufinterface ufinterface{get;set;}
    }
    public class Ufinterface
    {
        [XmlAttribute]
        public string roottag{get;set;}
        [XmlAttribute]
        public string billtype{get;set;}
        [XmlAttribute]
        public string subtype{get;set;}
        [XmlAttribute]
        public string replace{get;set;}
        [XmlAttribute]
        public string receiver{get;set;}
        [XmlAttribute]
        public string sender{get;set;}
        [XmlAttribute]
        public string proc{get;set;}
        [XmlAttribute]
        public string isexchange{get;set;}
        [XmlAttribute]
        public string filename{get;set;}
        public Voucher voucher { get; set; }
    }
    public class Voucher
    {
        //<voucher id="123456789">
        [XmlAttribute]
        public string id{get;set;}
        public Voucher_head voucher_head { get; set; }
        public Voucher_body voucher_body { get; set; }
    }
    public class Voucher_head
    {
        private string _defaultValue = "";
            //<!--是否预收预付标志 非空字段-->
            //    <prepay>n</prepay>
            public string prepay{get;set;}
            //<!--单位编码  非空字段-->
            //<corp>19</corp>
            public string corp{get;set;}
            //<!--业务类型 非空字段  D4是收款结算单,D5是付款结算单,D6是划账结算单,sysid都应该为2, 该数据项需要需要基础数据对照(单据类型)-->
            //<businessType>D5</businessType>
            public string businessType{get;set;}
            //<!--单据类型编码 非空字段  D4是收款结算单,D5是付款结算单,D6是划账结算单,sysid都应该为2, 该数据项需要需要基础数据对照(单据类型)-->
            //<billTypeCode>D5</billTypeCode>
            public string billTypeCode{get;set;}
            //<!--单据日期 非空字段-->
            //<billDate>2009-02-13</billDate>
            public string billDate{get;set;}
            //<!--系统编号 0应收 1应付 2现金平台  非空字段-->
            //<sysid>2</sysid>
             public string sysid{get;set;}
            //<!--是否期初单据 非空字段-->
            //<initFlag>n</initFlag>
            public string initFlag{get;set;}
            //<!--录入人 非空字段-->
            //<inputOp>yh</inputOp>
            public string inputOp{get;set;}
            //<!--采购类型编码-->
            //<saleType></saleType>
            public string saleType { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!--自由项-->
            //<freeitem1></freeitem1>
            //<freeitem2></freeitem2>
            //<freeitem3></freeitem3>
            //<freeitem4></freeitem4>
            //<freeitem5></freeitem5>
            //<freeitem6></freeitem6>
            //<freeitem7></freeitem7>
            //<freeitem8></freeitem8>
            //<freeitem9></freeitem9>
            //<freeitem10></freeitem10>
            //<freeitem11></freeitem11>
            //<freeitem12></freeitem12>
            //<freeitem13></freeitem13>
            //<freeitem14></freeitem14>
            //<freeitem15></freeitem15>
            //<freeitem16></freeitem16>
            //<freeitem17></freeitem17>
            //<freeitem18></freeitem18>
            //<freeitem19></freeitem19>
            //<freeitem20></freeitem20>
            //<!-- 自由项-->
            //<freeitem21></freeitem21>
            //<freeitem22></freeitem22>
            //<freeitem23></freeitem23>
            //<freeitem24></freeitem24>
            //<freeitem25></freeitem25>
            //<freeitem26></freeitem26>
            //<freeitem27></freeitem27>
            //<freeitem28></freeitem28>
            //<freeitem29></freeitem29>
            //<freeitem30></freeitem30>
            public string freeitem1 { get; set; }
            public string freeitem2 { get; set; }
            public string freeitem3 { get; set; }
            public string freeitem4 { get; set; }
            public string freeitem5 { get; set; }
            public string freeitem6 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem7 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem8 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem9 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem10 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem11 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem12 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem13 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem14 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem15 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem16 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem17 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem18 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem19 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem20 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem21 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem22{ get { return _defaultValue; } set { _defaultValue=value;} }
            public string freeitem23{ get { return _defaultValue; } set { _defaultValue=value;} }
            public string freeitem24{ get { return _defaultValue; } set { _defaultValue=value;} }
            public string freeitem25{ get { return _defaultValue; } set { _defaultValue=value;} }
            public string freeitem26 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem27 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem28 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem29 { get { return _defaultValue; } set { _defaultValue = value; } }
            public string freeitem30 { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!--收付款人-->
            //<teller></teller>
            public string teller { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!--科目编码-->
            //<subject></subject>
            public string subject { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!--票据号-->
            //<note_num></note_num>
            public string note_num { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!--票据结算方式-->
            //<settleType></settleType>
            public string settleType { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!--确认人-->
            //<affirmant></affirmant>
            public string affirmant { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!--银行确认人 如果导入的单据状态是签字态 ，则必须录入银行确认人（业务意义为签字人）-->
            //<bank_affirmant></bank_affirmant>
            public string bank_affirmant { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!--备注-->
            //<scomment></scomment>
            public string scomment{get;set;}
            //<!--附件，不能为空，默认为0-->
            //<appendix>0</appendix>
            public string appendix{get;set;}
            //<!--原币金额 非空字段,不能为0-->
            //<original_sum>125.00</original_sum>
            public decimal original_sum{get;set;}
            //<!--辅币金额 非空字段，默认为0-->
            //<fractional_sum>0</fractional_sum>
            public decimal fractional_sum{get;set;}
            //<!--本币金额 非空字段，应该与原币金额original_sum相同-->
            //<local_sum>125.00</local_sum>
            public decimal local_sum{get;set;}
            //<!---V5 新增-->

            //<!-- 单据状态 1保存 2审核 3签字确认-->
            //<billstatus>1</billstatus>
            public string billstatus{get;set;}
            //<!-- 内控账期日期 -->
            //<inner_effect_date></inner_effect_date>
            public string inner_effect_date { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!-- 客商开户银行 -->
            //<kskhyh></kskhyh>
            public string kskhyh { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!--事项审批单事由 -->
            //<sscause></sscause>
            public string sscause { get; set; }
            //<!-- 最终审批人  -->
            //<lastshr></lastshr>
            public string lastshr { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!--审批状态 -->
            //<spzt></spzt>
            public string spzt { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!--支付人 -->
            //<payman></payman>
            public string payman { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!-- 支付日期 -->
            //<paydate></paydate>
            public string paydate { get { return _defaultValue; } set { _defaultValue = value; } }
            //<!-- 暂估应付标志 -->
            //<zgyf></zgyf>
            public string zgyf { get { return _defaultValue; } set { _defaultValue = value; } }

			
    }
    public class Voucher_body
    {
        public Entry entry{get;set;}
    }
    public class Entry 
    {
        private string _defaultValue="";
        //<!--金额方向 非空字段-->
        //<sum_direction>1</sum_direction>
        public string sum_direction{get;set;}
        //<!--摘要-->
        //<digest>13日外部交换平台导入单据</digest>
        public string digest{get;set;}
        //<!--科目编码，需要对照-->
        //<subject>2121</subject>
        public string subject { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--客商主键，付款结算单不能为空，需要基础数据对照(供应商辅助核算)-->
        //<customer>204</customer>
        public string customer{get;set;}
        //<!--币种编码 非空字段，需要对照-->
        //<currencyId>CNY</currencyId>
        public string currencyId{get;set;}
        //<!--本币汇率 非空字段-->
        //<original_exchange_rate>1</original_exchange_rate>
        public decimal original_exchange_rate{get;set;}
        //<!--辅币汇率 非空字段-->
        //<fractional_exchange_rate>0.0</fractional_exchange_rate>
        public decimal fractional_exchange_rate{get;set;}
        //<!--项目编码-->
        //<job>2009</job>
        public string job { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--借方原币金额 非空字段-->
        //<debit_original_sum>125</debit_original_sum>
        public decimal debit_original_sum{get;set;}
        //<!--借方辅币金额 非空字段，默认为0-->
        //<debit_fractional_sum>0</debit_fractional_sum>
        public decimal debit_fractional_sum{get;set;}
        //<!--借方本币金额 非空字段-->
        //<debit_local_sum>125</debit_local_sum>
        public decimal debit_local_sum{get;set;}
        //<!--原币余额 非空字段-->
        //<original_balance>125</original_balance>
        public decimal original_balance{get;set;}
        //<!--辅币余额 非空字段，默认为0-->
        //<fractional_balance>0</fractional_balance>
        public decimal fractional_balance{get;set;}
        //<!--本币余额 非空字段-->
        //<local_balance>125</local_balance>
        public decimal local_balance{get;set;}
        //<!--数量余额 非空字段-->
        //<quantity_balance>1</quantity_balance>
        public decimal quantity_balance{get;set;}
        //<!--存货编码-->
        //<inventoryId></inventoryId>
        public string inventoryId { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--筹投资标志-->
        //<investFlag></investFlag>
        public string investFlag { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--借方数量 非空字段-->
        //<debit_quantity>1</debit_quantity>
        public decimal debit_quantity{get;set;}
        //<!--单价-->
        //<unit_price></unit_price>
        public string unit_price { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--税率-->
        //<tax_rate></tax_rate>
        public string tax_rate { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--借方原币税金 非空字段-->
        //<debit_original_tax>0</debit_original_tax>
        public decimal debit_original_tax{get;set;}
        //<!--借方辅币税金 非空字段-->
        //<debit_fractional_tax>0</debit_fractional_tax>
        public decimal debit_fractional_tax{get;set;}
        //<!--借方本币税金 非空字段-->
        //<debit_local_tax>0</debit_local_tax>
        public decimal debit_local_tax{get;set;}
        //<!--付款银行名称-->
        //<pay_bankName>19农行账户</pay_bankName>
        public string pay_bankName{get;set;}
        //<!--付款银行账户-->
        //<pay_accounts>19001农行</pay_accounts>
        public string pay_accounts{get;set;}
        //<!--付款银行地址-->
        //<pay_bank_addr></pay_bank_addr>
        public string pay_bank_addr { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--收款银行名称-->
        //<gather_bankName></gather_bankName>
        public string gather_bankName { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--收款银行账户 需特殊处理的字段,要求必须录入帐号编码-->
        //<gather_accounts></gather_accounts>
        public string gather_accounts { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--收款银行地址-->
        //<gather_bank_addr></gather_bank_addr>
        public string gather_bank_addr { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--自定义项-->
        //<freeitem1></freeitem1>
        //<freeitem2></freeitem2>
        //<freeitem3></freeitem3>
        //<freeitem4></freeitem4>
        //<freeitem5></freeitem5>
        //<freeitem6></freeitem6>
        //<freeitem7></freeitem7>
        //<freeitem8></freeitem8>
        //<freeitem9></freeitem9>
        //<freeitem10></freeitem10>
        //<freeitem11></freeitem11>
        //<freeitem12></freeitem12>
        //<freeitem13></freeitem13>
        //<freeitem14></freeitem14>
        //<freeitem15></freeitem15>
        //<freeitem16></freeitem16>
        //<freeitem17></freeitem17>
        //<freeitem18></freeitem18>
        //<freeitem19></freeitem19>
        //<freeitem20></freeitem20>
        //<!-- 自由项 -->
        //<freeitem21></freeitem21>
        //<freeitem22></freeitem22>
        //<freeitem23></freeitem23>
        //<freeitem24></freeitem24>
        //<freeitem25></freeitem25>
        //<freeitem26></freeitem26>
        //<freeitem27></freeitem27>
        //<freeitem28></freeitem28>
        //<freeitem29></freeitem29>
        //<freeitem30></freeitem30>
        public string freeitem1 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem2 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem3 { get { return _defaultValue; } set { _defaultValue = value; } }

        public string freeitem4 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem5 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem6 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem7 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem8 { get { return _defaultValue; } set { _defaultValue = value; } }

        public string freeitem9 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem10 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem11 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem12 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem13 { get { return _defaultValue; } set { _defaultValue = value; } }

        public string freeitem14 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem15 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem16 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem17 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem18 { get { return _defaultValue; } set { _defaultValue = value; } }

        public string freeitem19 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem20 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem21 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem22 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem23 { get { return _defaultValue; } set { _defaultValue = value; } }

        public string freeitem24 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem25 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem26 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem27 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem28 { get { return _defaultValue; } set { _defaultValue = value; } }

        public string freeitem29 { get { return _defaultValue; } set { _defaultValue = value; } }
        public string freeitem30 { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--订单号-->
        //<orderId></orderId>
        public string orderId { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--开票日期-->
        //<check_date></check_date>
        public string check_date { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--借方辅币无税金额 非空字段-->
        //<debit_frac_noTax>0</debit_frac_noTax>
        public decimal debit_frac_noTax{get;set;}
        //<!--贷方辅币无税金额 非空字段-->
        //<credit_frac_noTax>0</credit_frac_noTax>
        public decimal credit_frac_noTax{get;set;}
        //<!--借方本币无税金额 非空字段-->
        //<debit_local_noTax>125</debit_local_noTax>
        public decimal debit_local_noTax{get;set;}
        //<!--收入标志-->
        //<incomeFlag>y</incomeFlag>
        public string incomeFlag{get;set;}
        //<!--收支项目-->
        //<accsubjId>020303</accsubjId>
        public string accsubjId{get;set;}
        //<!--账户档案，或者为空，如果有值一定要建立对照-->
        //<accountid></accountid>
        public string accountid { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--收款协议号-->
        //<pay_agreementId></pay_agreementId>
        public string pay_agreementId { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--贷方原币金额 非空字段-->
        //<credit_original_sum>0</credit_original_sum>
        public decimal credit_original_sum{get;set;}
        //<!--贷方辅币金额 非空字段-->
        //<credit_frac_sum>0</credit_frac_sum>
        public decimal credit_frac_sum{get;set;}
        //<!--贷方本币金额 非空字段-->
        //<credit_local_sum>0</credit_local_sum>
        public decimal credit_local_sum{get;set;}
        //<!--贷方数量 非空字段-->
        //<credit_quantity>0</credit_quantity>
        public decimal credit_quantity{get;set;}
        //<!--贷方原币税金 非空字段-->
        //<credit_original_Tax>0</credit_original_Tax>
        public decimal credit_original_Tax{get;set;}
        //<!--贷方辅币税金 非空字段-->
        //<credit_frac_Tax>0</credit_frac_Tax>
        public decimal credit_frac_Tax{get;set;}
        //<!--贷方本币税金 非空字段-->
        //<credit_local_Tax>0</credit_local_Tax>
        public decimal credit_local_Tax{get;set;}
        //<!--往来对象 非空字段，0客户，1供应商，2部门，3业务员-->
        //<object>1</object>
        public string objecct{get;set;}
        //<!--借方原币无税金额 非空字段-->
        //<debit_original_noTax>125</debit_original_noTax>
        public decimal debit_original_noTax{get;set;}
        //<!--贷方原币无税金额 非空字段-->
        //<credit_original_noTax>0</credit_original_noTax>
        public decimal credit_original_noTax{get;set;}
        //<!--贷方本币无税金额 非空字段-->
        //<credit_local_noTax>0</credit_local_noTax>
        public decimal credit_local_noTax{get;set;}
        //<!--税号-->
        //<tax_num></tax_num>
        public string tax_num { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--项目阶段-->
        //<pk_jobobjpha></pk_jobobjpha>
        public string pk_jobobjpha { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--款项用途-->
        //<purpose_sum></purpose_sum>
        public string purpose_sum { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--部门编码-->
        //<deptid>002</deptid>
        public string deptid{get;set;}
        //<!--业务员编码-->
        //<employeeId>002</employeeId>
        public string employeeId{get;set;}
        //<!--含税单价-->
        //<unit_price_WithTax></unit_price_WithTax>
        public string unit_price_WithTax { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--扣税类别，不能为空，默认为0-->
        //<Tax_Type>0</Tax_Type>
        //<!--注意：客商、部门、业务员不能同时为空-->
        public string Tax_Type{get;set;}
        //<!-- V5新增  -->
        //<!-- 交易类型 -->
        //<tradertype>1</tradertype>
        public int tradertype{get;set;}
        //<!-- 批次号1 -->
        //<seqnum></seqnum>
        public string seqnum { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--散户 -->
        //<sanhu></sanhu>
        public string sanhu { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!-- 使用部门 -->
        //<usedept></usedept>
        public string usedept { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--固定资产卡片号 -->
        //<facardbh></facardbh>
        public string facardbh { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!-- 现金流量项目 -->
        //<cashitem></cashitem>
        public string cashitem { get { return _defaultValue; } set { _defaultValue = value; } }

        //<!-- 支付状态 -->
        //<payflag></payflag>
        public string payflag { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--报价单位无税单价 -->
        //<bjdwwsdj></bjdwwsdj>
        public string bjdwwsdj { get { return _defaultValue; } set { _defaultValue = value; } }

        //<!--出库单号 -->
        //<ckdh></ckdh>
        public string chdh { get { return _defaultValue; } set { _defaultValue = value; } }

        //<!--支付人 -->
        //<payman></payman>
        public string payman { get { return _defaultValue; } set { _defaultValue = value; } }

        //<!-- 支付日期 -->
        //<paydate></paydate>
        public string paydate { get { return _defaultValue; } set { _defaultValue = value; } }
        ////<!--项目阶段管理档案id -->
        ////<pk_jobobjpha></pk_jobobjpha>
        //public string pk_jobobjpha{get;set;}
		

        public Settlementinfo settlementinfo { get; set; }
    }

    public class Settlementinfo
    {
        public Settlement settlement{get;set;}
    }
    public class Settlement
    {
        private string _defaultValue = "";
        //<currency>CNY</currency>
        public string currency { get; set; }
        //<corp>19</corp>
        public string corp{ get; set; }
        //<pay>125</pay>
        public decimal pay { get; set; }
        //<paylocal>125</paylocal>
        public decimal paylocal { get; set; }
        //<receive></receive>
        public string receive { get { return _defaultValue; } set { _defaultValue = value; } }
        //<receivelocal></receivelocal>
        public string receivelocal { get { return _defaultValue; } set { _defaultValue = value; } }
        //<!--本方银行账户-->
        //<ownaccount>19001农行</ownaccount>
        public string ownaccount { get; set; }
        //<!--对方银行账户 需特殊处理的字段,要求必须录入帐号编码-->
        //<oppaccount>001</oppaccount>
        public string oppaccount { get; set; }
        //<localrate>1</localrate>
        public decimal localrate { get; set; }
        //<tradertype>1</tradertype>
        public string tradetype { get { return _defaultValue; } set { _defaultValue = value; } }
        //<balatype></balatype>
        public string balatype { get; set; }
        //<tradername>002</tradername>
        public string tradename { get; set; }
        //<memo>摘要信息</memo>
        public string memo { get; set; }
        //<notetype></notetype>
        public string notetype { get { return _defaultValue; } set { _defaultValue = value; } }
        //<notenumber></notenumber>
        public string notenumber { get { return _defaultValue; } set { _defaultValue = value; } }
        //<billtype></billtype>
        public string billtype { get { return _defaultValue; } set { _defaultValue = value; } }
        //<billcode></billcode>
        public string billcode { get { return _defaultValue; } set { _defaultValue = value; } }
        //<billdate></billdate>
        public string billdate { get; set; }
    }
}