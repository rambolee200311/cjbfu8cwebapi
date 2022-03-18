using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CjbfU8CwebAPI.Models.Bank
{
    public class BdBankDoc
    {
        public string system { get; set; }
        public string trantype { get; set; }
        public List<BankDoc> bankdoc { get; set; }
    }
}