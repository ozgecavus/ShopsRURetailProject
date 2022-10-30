
using ShopsRUsRetail.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Core.Repositories
{
    public interface IDiscountRepository :IRepositoryManager
    {
        Task<IEnumerable<DiscountType>> GetAllDiscounts();
        Task<DiscountType> GetDiscountPercentageByType(string type);
        void CreateDiscountType(DiscountType discount);
        string DiscountPercentage(DiscountType discount);

    }
}
