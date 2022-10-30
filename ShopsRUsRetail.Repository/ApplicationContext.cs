using Microsoft.EntityFrameworkCore;
using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Repository.Configurations;

namespace ShopsRUsRetail.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeedUserData());
            modelBuilder.ApplyConfiguration(new SeedDiscountData());
            modelBuilder.ApplyConfiguration(new SeedStoreTypeData());
      
        }
        
        public DbSet<DiscountType> DiscountType { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<Users> Users { get; set; }

        public DbSet<StoreType> StoreType { get; set; }
    }
}
