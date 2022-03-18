using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CjbfU8CwebAPI.Models.Fj
{
    public class FJ_billvo
    {
        public FJ_billvo_parentvo parentvo { get; set; }
        public List<FJ_billvo_children> children { get; set; }
    }
}