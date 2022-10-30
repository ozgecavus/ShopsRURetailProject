using Microsoft.EntityFrameworkCore;
using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Repository.Repositories
{
    public class StoreTypeRepository : RepositoryBase<StoreType>, IStoreTypeRepository
    {
        public StoreTypeRepository(ApplicationContext context):base(context) {  }

        public async Task<IEnumerable<StoreType>> GetStoreTypes() =>
          await FindAll(false).ToListAsync();

    }
}
