using ShopsRUsRetail.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Core.Services
{
    public interface IDiscountService
    {
        Task<IEnumerable<DiscountType>> GetAllDiscounts();
        Task<DiscountType> GetDiscount(string type);
        Task<int> CreateDiscount(DiscountType discounttype);
        string DiscountPercentage(DiscountType discount);
    }
}
