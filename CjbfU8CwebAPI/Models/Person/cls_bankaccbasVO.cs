using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CjbfU8CwebAPI.Models.Person
{
    public class cls_bankaccbasVO
    {
        public string accopendate { get; set; }//否
        public string account { get; set; }//是
        public string accountcode { get; set; }//是
        public string accountname { get; set; }//是
        public string bankarea { get; set; }//否
        public string city { get; set; }//否
        public string combineaccnum { get; set; }//否
        public string contactpsn { get; set; }//否
        public string custcode { get; set; }//否
        public string groupid { get; set; }//否
        public string memo { get; set; }//否
        public int netqueryflag { get; set; }//否
        public string orgnumber { get; set; }//否
        public string pk_bankdoc { get; set; }//是
        public string pk_banktype { get; set; }//是
        public string pk_currtype { get; set; }//是
        public string pk_netbankinftp { get; set; }//否
        public string province { get; set; }//否
        public string remcode { get; set; }//否
        public bool signflag { get; set; }//否
        public string tel { get; set; }//否
        public string unitname { get; set; }//否

    }
}