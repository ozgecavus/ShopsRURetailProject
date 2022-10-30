using ShopsRUsRetail.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Core.Repositories
{
    public interface IStoreTypeRepository
    {
        Task<IEnumerable<StoreType>> GetStoreTypes();
      
    }
}
