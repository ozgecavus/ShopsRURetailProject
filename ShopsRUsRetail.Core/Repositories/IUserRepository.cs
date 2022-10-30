using ShopsRUsRetail.Core.Entities;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace ShopsRUsRetail.Core.Repositories
{
    public interface IUserRepository : IRepositoryManager
    {
        Task<IEnumerable<Users>> GetAllUsers();
        void CreateUser(Users user);
        Task<Users> GetUserById(int customerId);
        Task<Users> GetUserByName(string name);
        void DeleteUser(Users user);
    }
}
