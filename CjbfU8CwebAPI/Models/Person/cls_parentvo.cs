using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CjbfU8CwebAPI.Models.Person
{
    public class cls_parentvo
    {
        public string currentcorp { get; set; }//公司主属性
        public cls_psnbasvo psnbasvo { get; set; }
        public cls_psnmanvo psnmanvo { get; set; }
    }
}