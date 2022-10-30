using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using ShopsRUs;
using ShopsRUsRetail.Repository;
using ShopsRUsRetail.Core.Entities;

namespace ShopsRURetail.Test
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;
 

        protected IntegrationTest()
        {
      
            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationContext>));

                        if (descriptor != null) services.Remove(descriptor);

                        services.AddDbContext<ApplicationContext>(options =>
                        {
                            options.UseInMemoryDatabase("InMemoryDbForTesting");
                        });
                    });
                });

            TestClient = appFactory.CreateClient();

            SeedData(appFactory);
     
        }

        private static void SeedData(WebApplicationFactory<Program> appFactory)
        {
            try
            {
                var scopeFactory = appFactory.Server.Services.GetService<IServiceScopeFactory>();
                if (scopeFactory is null) return;

                using IServiceScope scope = scopeFactory.CreateScope();

                var context = scope.ServiceProvider.GetService<ApplicationContext>();
                if (context is null) return;


                var discountTypeAffiliate = context.DiscountType.AddAsync(new DiscountType { Id = 1, Name = "Affiliate Discount", Type = "Affiliate", Rate = 10, IsRatePercentage = true }).Result.Entity;
                var discountTypeEmployee = context.DiscountType.AddAsync(new DiscountType { Id = 2, Name = "Employee Discount", Type = "Employee", Rate = 30, IsRatePercentage = true }).Result.Entity;
                var discountTypeCustomer = context.DiscountType.AddAsync(new DiscountType { Id = 3, Name = "Loyal Customer Discount", Type = "Customer", Rate = 5, IsRatePercentage = true }).Result.Entity;
                var discountTypePrice = context.DiscountType.AddAsync(new DiscountType { Id = 4, Name = "Price Discount", Type = "Price", Rate = 5, IsRatePercentage = false }).Result.Entity;


                var storeTypeGrocery = context.StoreType.AddAsync(new StoreType { Id = 1, Name = "GROCERY", IsPercantageDiscount = 0 }).Result.Entity;
                var storeTypeOther = context.StoreType.AddAsync(new StoreType { Id = 2, Name = "OTHER", IsPercantageDiscount = 1 }).Result.Entity;

                var userCustomer = context.Users.AddAsync(new Users { UserId = 1, UserType = "Customer", FirstName = "testcustomer", LastName = "testcustomer", MiddleName = "testcustomer", Address = "test", Email = "testcustomer@gmail.com", PhoneNumber = "1122334455" }).Result.Entity;
                var userAffiliate = context.Users.AddAsync(new Users { UserId = 2, UserType = "Affiliate", FirstName = "testaffiliate", LastName = "testaffiliate", MiddleName = "testaffiliate", Address = "test", Email = "testaffiliate@gmail.com", PhoneNumber = "1122334455" }).Result.Entity;
                var userEmployee = context.Users.AddAsync(new Users { UserId = 3, UserType = "Employee", FirstName = "testemployee", LastName = "testemployee", MiddleName = "testemployee", Address = "test", Email = "testemployee@gmail.com", PhoneNumber = "1122334455" }).Result.Entity;


                //var invoiceCustomer = context.Invoices.AddAsync(new Invoice { UserId = 1, StoreTypeId = 2, TotalAmount = 100, OrderId = 1, InvoiceNumber = "TEST1122331", InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = 100, ProductQuantity = 1, ProductPrice = 100 } } }).Result.Entity;
                //var invoiceAffiliate = context.Invoices.AddAsync(new Invoice { UserId = 2, StoreTypeId = 2, TotalAmount = 100, OrderId = 1, InvoiceNumber = "TEST1122333", InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = 100, ProductQuantity = 1, ProductPrice = 100 } } }).Result.Entity;
                //var invoiceEmployee = context.Invoices.AddAsync(new Invoice { UserId = 3, StoreTypeId = 2, TotalAmount = 100, OrderId = 1, InvoiceNumber = "TEST1122332", InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = 100, ProductQuantity = 1, ProductPrice = 100 } } }).Result.Entity;

                context.SaveChanges();
            
            }
            catch
            {

            }
           
        }

    }
}
