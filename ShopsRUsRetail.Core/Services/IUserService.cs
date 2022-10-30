using ShopsRUsRetail.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<int> CreateUsers(Users userEntity);
        Task<Users> GetUserById(int Id);
        Task<Users> GetUserByName(string name);
        Task DeleteUser(Users user);
    }
}
