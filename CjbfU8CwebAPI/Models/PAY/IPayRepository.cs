using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CjbfU8CwebAPI.Models.PAY
{
    public interface IPayRepository
    {
        Pay GetPay(string id);
        Result AddPay(Pay item);
        bool RemovePay(string id);
        bool UpdatePay(string id, Pay item);
    }
}
