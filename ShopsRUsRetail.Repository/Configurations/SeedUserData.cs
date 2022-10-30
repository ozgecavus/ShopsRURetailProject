using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRUsRetail.Core.Entities;
using System;


namespace ShopsRUsRetail.Repository.Configurations
{
    public class SeedUserData : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasData
            (
                new Users
                {
                    UserId = 1,
                    FirstName = "ozge",
                    MiddleName = "aksu",
                    LastName = "cavus",
                    Email = "user1@email.com",
                    PhoneNumber = "123456789",
                    UserType = "Customer",
                    DateCreated = DateTime.Now.AddYears(-3)
                },
             
                new Users
                {
                    UserId = 2,
                    FirstName = "simge",
                    MiddleName = "-",
                    LastName = "aksu",
                    Email = "user2@email.com",
                    PhoneNumber = "123456789",
                    UserType = "Affiliate",
                    DateCreated = DateTime.Now.AddYears(-1)
                },
                new Users
                {
                    UserId = 3,
                    FirstName = "Ahmet", 
                    LastName = "Cavus",
                    Email = "user3@email.com",
                    PhoneNumber = "123456789",
                    UserType = "Employee",
                    DateCreated = DateTime.Now.AddYears(-5)
                }
            );
        }
    }
}
