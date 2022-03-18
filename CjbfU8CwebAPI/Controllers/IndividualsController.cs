using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CjbfU8CwebAPI.Models.Person;
using CjbfU8CwebAPI.Models.Fj;
using CjbfU8CwebAPI.Models.PAY;
using CjbfU8CwebAPI.Models.Bank;

namespace CjbfU8CwebAPI.Controllers
{
    public class IndividualsController : ApiController
    {
        // GET api/individuals
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/individuals/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/individuals
        public string Post([FromBody]Pay pay)
        {
            //cls_person psn = new cls_person();
            //psn = PersonRepository.Add_Person(pay);
            //return psn;
            //增加银行档案
            //BdBankDocRepository bdbankrepo = new BdBankDocRepository();
            //bdbankrepo.SaveBdBankDoc(pay);

            PersonRepository.Add_Person(pay);
            return "it is ok";
        }

        // PUT api/individuals/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/individuals/5
        public void Delete(int id)
        {
        }
    }
}
