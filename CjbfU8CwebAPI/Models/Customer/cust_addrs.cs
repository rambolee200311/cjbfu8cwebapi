using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CjbfU8CwebAPI.Models.Customer
{
    //客商地址
    public class Cust_addrs
    {
        public string addrname { get; set; }
        public bool defaddrflag { get; set; }
        public string linkman { get; set; }
        public string phone { get; set; }
        public string pk_address { get; set; }
        public string pk_areacl { get; set; }
        public string pk_cubasdoc { get; set; }
        public string pk_route { get; set; }      
    }
}