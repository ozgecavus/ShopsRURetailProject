using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRUsRetail.Core.Entities;


namespace ShopsRUsRetail.Repository.Configurations
{
    public class SeedStoreTypeData : IEntityTypeConfiguration<StoreType>
    {
        public void Configure(EntityTypeBuilder<StoreType> builder)
        {
            builder.HasData
            (
                new StoreType
                {
                    Id = 1,
                    Name = "GROCERY",
                    IsPercantageDiscount = 0,
                    
                },
             
                new StoreType
                {
                    Id=2,
                    Name = "OTHER",
                    IsPercantageDiscount = 1,
                }
                
            );
        }
    }
}
