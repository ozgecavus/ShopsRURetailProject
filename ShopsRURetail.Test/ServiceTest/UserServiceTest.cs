
using AutoMapper;
using Moq;
using ShopsRUs.Controllers;
using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Entities.DTOs;
using ShopsRUsRetail.Core.Repositories;
using ShopsRUsRetail.Core.Services;
using ShopsRUsRetail.Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ShopsRURetail.Test
{
    public class UserServiceTest
    {


        private UserService userService { get; set; }
        private Mock<IUserRepository> mockIUserRepository = new Mock<IUserRepository>();


        public UserServiceTest()
        {
            this.userService = new UserService(mockIUserRepository.Object);

        }

        [Theory]
        [InlineData("Customer", "test1", "test2", "Customer", "test1", "test2")]
        public async void AddUser_ShouldBeCreated_WhenGivenValue_ReturnSuccess(string expecteduserType, string expectedfirstName, string expectedlastName, string actualuserType, string actualfirstName, string actuallastName)
        {

            var user = new Users
            {
                UserType = actualuserType,
                FirstName = actualfirstName,
                LastName = actuallastName,
                MiddleName = "",
                PhoneNumber = "",
                Address = "",
                Email = "",
            };

            Users actual = null;
            mockIUserRepository.Setup(item => item.CreateUser(It.IsAny<Users>()))
                      .Callback(new InvocationAction(i => actual = (Users)i.Arguments[0]));

            Users expecteduser = new Users
            {
                UserType = expecteduserType,
                FirstName = expectedfirstName,
                LastName = expectedlastName,
                MiddleName = "",
                PhoneNumber = "",
                Address = "",
                Email = "",
            };

            await userService.CreateUsers(user);
            Assert.Equal(expecteduser.FirstName, actual.FirstName);
            Assert.Equal(expecteduser.LastName, actual.LastName);
            Assert.Equal(expecteduser.UserType, actual.UserType);


        }

        //[Fact]
        //public async void AddUser_Failed_WhenGivenNullValue_ReturnError()
        //{
        //    try
        //    {
        //        int userId = await userService.CreateUsers(null);
        //        Assert.Equal(1, 0);
        //    }
        //    catch (Exception)
        //    {

        //        Assert.False(false);
        //    }

        //}

        [Theory]
        [InlineData("ozge", "ozge")]
        public async void GetUser_ShouldBeSame_WhenGivenValue_ReturnSuccess(string userName, string expectedUserName)
        {
            mockIUserRepository.Setup(rep => rep.GetUserByName(It.IsAny<string>())).ReturnsAsync(new Users { FirstName = userName });
            Users result = await userService.GetUserByName(userName);
            Assert.Equal(expectedUserName, result.FirstName);

        }


    }
}

