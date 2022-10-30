using Microsoft.EntityFrameworkCore;
using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Repository.Repositories
{
    public class DiscountRepository : RepositoryBase<DiscountType>, IDiscountRepository
    {
        public DiscountRepository(ApplicationContext context) :base(context) { }
        public void CreateDiscountType(DiscountType discount) => Create(discount);

        public string DiscountPercentage(DiscountType discount)
        {
            if (discount.IsRatePercentage) return $"{discount.Rate}%";
            return null;
        }

        public async Task<IEnumerable<DiscountType>> GetAllDiscounts() =>
            await FindAll(false).OrderBy(d => d.Name).ToListAsync();

        public async Task<DiscountType> GetDiscountPercentageByType(string type) =>
            await FindByCondition(d => d.Type.Trim().ToLower()
                .Equals(type.Trim().ToLower()), false).SingleOrDefaultAsync();

    }
}
