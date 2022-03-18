using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CjbfU8CwebAPI.Models;
using CjbfU8CwebAPI.Models.PAY;
using CjbfU8CwebAPI.Helper;

namespace CjbfU8CwebAPI.Controllers
{

    public class ApplypayController : ApiController
    {
        private static readonly IPayRepository _Pays = new PayRepository(string.Empty);
        // GET api/applypay
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/applypay/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/applypay
        public Result Post([FromBody]Pay value)
        {
            Result re =new Result();
            bool proc = clsXmlProc.getXml(value.billId);
            if (proc)
            {
                clsXmlProc.setXml(value.billId, DateTime.Now.AddMinutes(10));
                re = _Pays.AddPay(value);
            }
            else
            {
                gepsInterface gi = new gepsInterface();
                Voucher voucher = new Voucher();
                voucher.billID = value.billId;
                voucher.billModuleCode = value.billModuleCode;
                voucher.syncState = "0";
                voucher.remark = "重复同步付款申请单";
                voucher.syncState = "add";
                voucher.syncTime = DateTime.Now;
                gi.voucher = voucher;
                re.GepsInterface = gi;
            }
            return re;
        }


        // PUT api/applypay/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/applypay/5
        public void Delete(int id)
        {
        }
    }
}
