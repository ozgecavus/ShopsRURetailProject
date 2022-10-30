using Microsoft.EntityFrameworkCore;
using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Repository.Repositories
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public UserRepository(ApplicationContext context):base(context) {  }
        public void CreateUser(Users user)
        {
            Create(user); 
        }

        public async Task<Users> GetUserById(int userId) =>
            await FindByCondition(u => u.UserId.Equals(userId), false).SingleOrDefaultAsync();

        public async Task<IEnumerable<Users>> GetAllUsers() =>
                await FindAll(false).OrderBy(d => d.UserId).ToListAsync();
       

        public async Task<Users> GetUserByName(string name) =>
            await FindByCondition(c => c.LastName.Trim().ToLower().Contains(name) ||
            c.MiddleName.Trim().ToLower().Contains(name) ||
            c.FirstName.Trim().ToLower().Contains(name)
           , false).SingleOrDefaultAsync();

        public void DeleteUser(Users user)
        {
            Delete(user);
        }
    }
}
