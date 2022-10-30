using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Core.Repositories
{
    public interface IRepositoryManager
    { 
        Task SaveAsync(); 
    }
}
