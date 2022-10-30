using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopsRUsRetail.Core.Repositories;
using ShopsRUsRetail.Core.Services;
using ShopsRUsRetail.Repository;
using ShopsRUsRetail.Repository.Repositories;
using ShopsRUsRetail.Service.Services;

namespace ShopsRUs.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IStoreTypeRepository, StoreTypeRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();

            services.AddScoped<IServiceManager, ServiceManager>();
        }
        


        public static void ConfigureSqlLite(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("sqlLiteConnection")));
    }
}
