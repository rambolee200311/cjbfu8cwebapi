using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CjbfU8CwebAPI.Models;
using CjbfU8CwebAPI.Helper;
using CjbfU8CwebAPI.Models.PAY;
using CjbfU8CwebAPI.Models.Person;

namespace CjbfU8CwebAPI.Models.Person
{
    public class PersonRepository
    {
        
        public static void Add_Person(Pay pay)
        {
            string url = "https://api.yonyoucloud.com/apis/u8c/uapbd/bdpsn_save";//请求接口地址
            string method = "POST";
            string apicode = "fe0f18f081a347e6a414011765ce0d91"; //配置您申请的appkey

            cls_person person = new cls_person();
            person.psn =new  List<cls_psn>();
            cls_psn single_psn = new cls_psn();

            single_psn.parentvo=new cls_parentvo();
            single_psn.parentvo.currentcorp = "001001";

            single_psn.parentvo.psnbasvo = new cls_psnbasvo();
            single_psn.parentvo.psnbasvo.psnname=pay.cperson;

            single_psn.parentvo.psnmanvo = new cls_psnmanvo();
            single_psn.parentvo.psnmanvo.pk_psncl = "01";
            single_psn.parentvo.psnmanvo.psncode = pay.billId;
            single_psn.parentvo.psnmanvo.clerkcode = pay.billId;
            single_psn.parentvo.psnmanvo.clerkflag = "Y";
            single_psn.parentvo.psnmanvo.pk_deptdoc = "9999";

            single_psn.childrenvo = new List<cls_childrenvo>();
            cls_childrenvo children = new cls_childrenvo();

            children.bankaccbasVO = new cls_bankaccbasVO();
            children.bankaccbasVO.account = pay.caccount;
            children.bankaccbasVO.accountcode = pay.caccount;
            children.bankaccbasVO.pk_banktype = "04";
            children.bankaccbasVO.unitname = pay.cperson;
            children.bankaccbasVO.accountname = pay.cperson;
            children.bankaccbasVO.pk_currtype = "CNY";
            children.bankaccbasVO.signflag = false;
            children.bankaccbasVO.pk_bankdoc = pay.cbankcode;
            children.bankaccbasVO.combineaccnum = pay.cbankcode;

            children.psnaccbankVO = new cls_psnaccbankVO();
            children.psnaccbankVO.isreimburse = true;

            single_psn.childrenvo.Add(children);

            person.psn.Add(single_psn);

            //post data
            var headerParams = new Dictionary<string, string>();
            headerParams.Add("apicode", apicode);
            headerParams.Add("system", "1");
            headerParams.Add("trantype", "code");
            headerParams.Add("authoration", "apicode");

            string bodyParams = JsonHelper.ToJson(person);
            LogHelper.Default.WriteInfo(bodyParams);
            string strResult = HttpPostHelper.sendInsert(url, bodyParams, headerParams, method);
            LogHelper.Default.WriteInfo(strResult);
        }
    }
}