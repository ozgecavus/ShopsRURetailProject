using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Entities.DTOs;
using ShopsRUsRetail.Core.Repositories;
using ShopsRUsRetail.Core.Services;

namespace ShopsRUsRetail.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;



        public UserService(IUserRepository repository)
        {
            _repository = repository;
      
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            var users = await _repository.GetAllUsers();
            return users;

        }


        public async Task<int> CreateUsers(Users userEntity)
        {
            _repository.CreateUser(userEntity);
            await _repository.SaveAsync();

            return userEntity.UserId;

        }


        public async Task<Users> GetUserById(int Id)
        {
            var user = await _repository.GetUserById(Id);
            return user;
        }

     
        public async Task<Users> GetUserByName(string name)
        {
            var user = await _repository.GetUserByName(name.Trim().ToLower());
            return user;
        }


        public async Task DeleteUser(Users user)
        {
            _repository.DeleteUser(user);
            await _repository.SaveAsync();

        }

 
    }
}
