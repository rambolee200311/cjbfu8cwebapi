using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CjbfU8CwebAPI.Helper;
using CjbfU8CwebAPI.Models.CMP;
using CjbfU8CwebAPI.Models.BD;
using CjbfU8CwebAPI.Models.Fj;
namespace CjbfU8CwebAPI.Models.PAY
{
    public class PayRepository:IPayRepository
    {
        public PayRepository(string strParam)
        {
            //do nothing

        }
        public Result AddPay(Pay item)
        {
            //Result re 
            Result re = new Result();
            gepsInterface gi = new gepsInterface();
            Voucher voucher = new Voucher();
            voucher.billID = item.billId;
            voucher.billModuleCode = item.billModuleCode;
            //voucher.syncState = "add";


            try
            {                            

                FjInsert fjinsert = new FjInsert();
                fjinsert.InsertFj(item, voucher);

            }
            catch(Exception ex)
            {
                voucher.syncState = "0";
                voucher.remark = ex.Message;
            }
            finally
            {
                voucher.syncState = "add";
                voucher.syncTime = DateTime.Now;
                gi.voucher = voucher;
                re.GepsInterface = gi;
                LogHelper.Default.WriteInfo(JsonHelper.ToJson(re));
            }
            
            return re;
        }
        public Pay GetPay(string id)
        {
            //do nothing
            return null;
        }
        public bool RemovePay(string id)
        {
            //do nothing
            return false;
        }
        public bool UpdatePay(string id, Pay item)
        {
            //do nothing
            return false;
        }

        public void BakEAI()
        {
            //CjbfU8CwebAPI.Models.Voucher voucher = new CjbfU8CwebAPI.Models.Voucher();

            //string Filename = "cmp_busibill_";
            //Filename += Guid.NewGuid();
            //Filename += ".xml";
            ////add cust
            //BscubasRepository.BscubasProc(item.ccusname, item.cbank, item.cbankcode, item.caccount);


            //cmpbusbill;// via json add vouch 
            CmpBusBill cbb = new CmpBusBill();

            //Ufinterface ufinterface = new Ufinterface();
            //Voucher vouch = new Voucher();
            //Voucher_head vhead = new Voucher_head();
            //Voucher_body vbody = new Voucher_body();
            //Entry entry = new Entry();
            //Settlementinfo settlementinfo = new Settlementinfo();
            //Settlement settlement = new Settlement();
            //#region//assgignvalues
            ///*
            //         * <ufinterface roottag="voucher" billtype="D5" subtype="run" replace="Y"
            //            receiver="001" sender="gld" proc="add" isexchange="Y"
            //            filename="cmp_busibill.xml">
            //         */
            //ufinterface.roottag = "voucher";
            //ufinterface.billtype = "D5";
            //ufinterface.subtype = "run";
            //ufinterface.replace = "Y";
            //ufinterface.receiver = "001001";
            //ufinterface.sender = "gld";
            //ufinterface.proc = "add";
            //ufinterface.isexchange = "Y";
            //ufinterface.filename = Filename;

            //vouch.id = item.ccode;

            ////<!--是否预收预付标志 非空字段-->
            ////<prepay>n</prepay>
            //vhead.prepay = "n";
            ////    <!--单位编码  非空字段-->
            ////<corp>001</corp>
            //vhead.corp = "001001";
            ////    <!--单据日期 非空字段-->
            ////<billDate>2019-07-31</billDate>
            //vhead.billDate = item.ddate.ToShortDateString();
            ////<!--系统编号 0应收 1应付 2现金平台  非空字段-->
            ////<sysid>2</sysid>
            //vhead.sysid = "2";
            ////<!--是否期初单据 非空字段-->
            ////<initFlag>n</initFlag>
            //vhead.initFlag = "n";
            ////<!--录入人 非空字段-->
            ////<inputOp>ljq</inputOp>
            //vhead.inputOp = "ljq";
            ////<!--备注-->
            ////<scomment></scomment>
            //vhead.scomment = item.cmemo;
            ////<!--附件，不能为空，默认为0-->
            ////<appendix>0</appendix>
            //vhead.appendix = "0";
            ////<!--原币金额 非空字段,不能为0-->
            ////<original_sum>125.00</original_sum>
            //vhead.original_sum = item.famount;
            ////<!--辅币金额 非空字段，默认为0-->
            ////<fractional_sum>0</fractional_sum>
            //vhead.fractional_sum = 0;
            ////<!--本币金额 非空字段，应该与原币金额original_sum相同-->
            ////<local_sum>125.00</local_sum>
            //vhead.local_sum = item.famount;
            ////<!-- 单据状态 1保存 2审核 3签字确认-->
            ////<billstatus>1</billstatus>
            //vhead.billstatus = "1";
            ////<!--事项审批单事由 -->
            ////<sscause></sscause>
            //vhead.sscause = "";// item.billModuleCode+"_"+item.billId+"_"+item.cperson;
            //vhead.billTypeCode = "D5";
            //vhead.freeitem1 = item.ccode;
            //vhead.freeitem2 = item.billModuleCode;
            //vhead.freeitem3 = item.billId;
            //vhead.freeitem4 = item.cperson;
            //vhead.freeitem5 = item.cbankcode;
            ////<!--金额方向 非空字段-->
            ////<sum_direction>1</sum_direction>
            //entry.sum_direction = "1";
            ////<!--摘要-->
            ////<digest>13日外部交换平台导入单据</digest>
            //entry.digest = item.cmemo;
            ////<!--客商主键，付款结算单不能为空，需要基础数据对照(供应商辅助核算)-->
            ////<customer>204</customer>
            //entry.customer = item.ccusname;
            ////<!--币种编码 非空字段，需要对照-->
            ////<currencyId>CNY</currencyId>
            //entry.currencyId = "CNY";
            ////<!--本币汇率 非空字段-->
            ////<original_exchange_rate>1</original_exchange_rate>
            //entry.original_exchange_rate = 1;
            ////<!--辅币汇率 非空字段-->
            ////<fractional_exchange_rate>0.0</fractional_exchange_rate>
            //entry.fractional_exchange_rate = 0;
            ////<!--借方原币金额 非空字段-->
            ////<debit_original_sum>125</debit_original_sum>
            //entry.debit_original_sum = item.famount;
            ////<!--借方辅币金额 非空字段，默认为0-->
            ////<debit_fractional_sum>0</debit_fractional_sum>
            //entry.debit_fractional_sum = 0;
            ////<!--借方本币金额 非空字段-->
            ////<debit_local_sum>125</debit_local_sum>
            //entry.debit_local_sum = item.famount;
            ////<!--原币余额 非空字段-->
            ////<original_balance>125</original_balance>
            //entry.original_balance = item.famount;
            ////<!--辅币余额 非空字段，默认为0-->
            ////<fractional_balance>0</fractional_balance>
            //entry.fractional_balance = 0;
            ////<!--本币余额 非空字段-->
            ////<local_balance>125</local_balance>
            //entry.local_balance = item.famount;
            ////<!--数量余额 非空字段-->
            ////<quantity_balance>1</quantity_balance>
            //entry.quantity_balance = 1;
            ////<!--借方数量 非空字段-->
            ////<debit_quantity>1</debit_quantity>
            //entry.debit_quantity = 1;
            ////<!--借方原币税金 非空字段-->
            ////<debit_original_tax>0</debit_original_tax>
            //entry.debit_original_tax = 0;
            ////<!--借方辅币税金 非空字段-->
            ////<debit_fractional_tax>0</debit_fractional_tax>
            //entry.debit_fractional_tax = 0;
            ////<!--借方本币税金 非空字段-->
            ////<debit_local_tax>0</debit_local_tax>
            //entry.debit_local_tax = 0;
            ////<!--付款银行名称-->
            ////<pay_bankName>19农行账户</pay_bankName>
            //entry.pay_bankName = item.cbank;
            ////<!--付款银行账户-->
            ////<pay_accounts>19001农行</pay_accounts>
            //entry.pay_accounts = "01001010001";
            ////<!--借方辅币无税金额 非空字段-->
            ////<debit_frac_noTax>0</debit_frac_noTax>
            //entry.debit_frac_noTax = 0;
            ////<!--贷方辅币无税金额 非空字段-->
            ////<credit_frac_noTax>0</credit_frac_noTax>
            //entry.credit_frac_noTax = 0;
            ////<!--借方本币无税金额 非空字段-->
            ////<debit_local_noTax>125</debit_local_noTax>
            //entry.debit_local_noTax = item.famount;
            ////<!--收入标志-->
            ////<incomeFlag>y</incomeFlag>
            //entry.incomeFlag = "y";
            ////<!--收支项目-->
            ////<accsubjId>020303</accsubjId>
            //entry.accsubjId = item.ccosttype;
            ////<!--贷方原币金额 非空字段-->
            ////<credit_original_sum>0</credit_original_sum>
            //entry.credit_original_sum = 0;
            ////<!--贷方辅币金额 非空字段-->
            ////<credit_frac_sum>0</credit_frac_sum>
            //entry.credit_frac_sum = 0;
            ////<!--贷方本币金额 非空字段-->
            ////<credit_local_sum>0</credit_local_sum>
            //entry.credit_local_sum = 0;
            ////<!--贷方数量 非空字段-->
            ////<credit_quantity>0</credit_quantity>
            //entry.credit_quantity = 0;
            ////<!--贷方原币税金 非空字段-->
            ////<credit_original_Tax>0</credit_original_Tax>
            //entry.credit_original_Tax = 0;
            ////<!--贷方辅币税金 非空字段-->
            ////<credit_frac_Tax>0</credit_frac_Tax>
            //entry.credit_frac_Tax = 0;
            ////<!--贷方本币税金 非空字段-->
            ////<credit_local_Tax>0</credit_local_Tax>
            //entry.credit_local_Tax = 0;
            ////<!--往来对象 非空字段，0客户，1供应商，2部门，3业务员-->
            ////<object>1</object>
            //entry.objecct = "1";
            ////<!--借方原币无税金额 非空字段-->
            ////<debit_original_noTax>125</debit_original_noTax>
            //entry.debit_original_noTax = item.famount;
            ////<!--贷方原币无税金额 非空字段-->
            ////<credit_original_noTax>0</credit_original_noTax>
            //entry.credit_original_noTax = 0;
            ////<!--贷方本币无税金额 非空字段-->
            ////<credit_local_noTax>0</credit_local_noTax>
            //entry.credit_local_noTax = 0;
            ////<!--部门编码-->
            ////<deptid>002</deptid>
            //entry.deptid = item.cprojectcode;
            ////<!--业务员编码-->
            ////<employeeId>002</employeeId>
            //entry.employeeId = "";
            ////<!--扣税类别，不能为空，默认为0-->
            ////<Tax_Type>0</Tax_Type>
            ////<!--注意：客商、部门、业务员不能同时为空-->
            //entry.Tax_Type = "0";
            ////<!-- 交易类型 -->
            ////<tradertype>1</tradertype>
            //entry.tradertype = 0;

            ////<currency>CNY</currency>
            //settlement.currency = "CNY";
            ////<corp>19</corp>
            //settlement.corp = "001";
            ////<pay>125</pay>
            //settlement.pay = item.famount;
            ////<paylocal>125</paylocal>
            //settlement.paylocal = item.famount;
            ////<!--本方银行账户-->
            ////<ownaccount>19001农行</ownaccount>
            //settlement.ownaccount = "01001010001";
            ////<!--对方银行账户 需特殊处理的字段,要求必须录入帐号编码-->
            ////<oppaccount>001</oppaccount>
            //settlement.oppaccount = item.caccount;
            ////<localrate>1</localrate>
            //settlement.localrate = 1;
            ////<tradertype>1</tradertype>
            //settlement.tradetype = "1";
            ////<tradername>002</tradername>
            //settlement.tradename = "002";
            ////<memo>摘要信息</memo>
            //settlement.memo = item.cmemo;
            //settlement.balatype = item.csettletype;
            //settlement.billdate = item.ddate.ToShortDateString();
            //#endregion


            //settlementinfo.settlement = settlement;
            //entry.settlementinfo = settlementinfo;
            //vbody.entry = entry;
            //vouch.voucher_head = vhead;
            //vouch.voucher_body = vbody;
            //ufinterface.voucher = vouch;
            //cbb.ufinterface = ufinterface;


            //#region//post EAI
            //string result = ObjToXml.CmpObjToXml(cbb, Filename);

            //#endregion
            //voucher.billID = item.billId;
            //voucher.billModuleCode = item.billModuleCode;
            //voucher.syncState = "add";
            ////voucher.remark = result;

            //ResultProc.ResultVoucherProc(voucher, result);
            //voucher.syncTime = DateTime.Now;
        }
    }
}