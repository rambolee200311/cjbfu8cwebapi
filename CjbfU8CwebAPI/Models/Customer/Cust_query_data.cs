using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CjbfU8CwebAPI.Models.Customer
{
    public class Cust_query_data
    {
        public int allcount { get; set; }
        public int retcount { get; set; }
        public List<Cust_query_data_detail> datas { get; set; }

        //public string datas { get; set; }
    }
}