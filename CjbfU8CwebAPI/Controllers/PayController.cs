using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CjbfU8CwebAPI.Controllers
{
    public class PayController : ApiController
    {
        // GET api/pay
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/pay/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/pay
        public void Post([FromBody]string value)
        {
        }

        // PUT api/pay/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/pay/5
        public void Delete(int id)
        {
        }
    }
}
