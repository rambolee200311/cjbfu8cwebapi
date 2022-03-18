using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CjbfU8CwebAPI.Models.Customer
{
    public class Cust_query_data_detail
    {
        public Cust_parentvo parentvo { get; set; }
        public List<Cust_addrs> ADDR { get; set; }
        public List<Cust_banks> BANK { get; set; }
        
    }
}