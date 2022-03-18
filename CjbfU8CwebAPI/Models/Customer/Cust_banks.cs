using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CjbfU8CwebAPI.Models.Customer
{
    public class Cust_banks
    {
        public string accaddr { get; set; }
        public string account { get; set; }
        public string accountname { get; set; }
        public bool defflag { get; set; }
        public string memo { get; set; }
        public string pk_accbank { get; set; }
        public string pk_bankdoc { get; set; }
        public string pk_banktype { get; set; }
        public string pk_corp { get; set; }
        public string pk_cubasdoc { get; set; }
        public string pk_currtype { get; set; }
    }
}