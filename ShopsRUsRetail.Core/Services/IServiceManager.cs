using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Core.Services
{
    public interface IServiceManager
    {
        IDiscountService DiscountService { get; }
        IInvoiceService InvoiceService { get; }
        IUserService UserService { get; }
    }
}
