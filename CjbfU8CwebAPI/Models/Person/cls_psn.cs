using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CjbfU8CwebAPI.Models.Person
{
    public class cls_psn
    {
        public List<cls_childrenvo> childrenvo { get; set; }
        public cls_parentvo parentvo { get; set; }
    }
}