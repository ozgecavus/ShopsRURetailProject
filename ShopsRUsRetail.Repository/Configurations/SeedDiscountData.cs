using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRUsRetail.Core.Entities;


namespace ShopsRUsRetail.Repository.Configurations
{
    public class SeedDiscountData : IEntityTypeConfiguration<DiscountType>
    {
        public void Configure(EntityTypeBuilder<DiscountType> builder)
        {
            builder.HasData
            (
                new DiscountType
                {
                    Id = 1,
                    Name = "Affiliate Discount",
                    Type = "Affiliate",
                    Rate = 10,
                    IsRatePercentage = true
                },
                new DiscountType
                {
                    Id = 2,
                    Name = "Employee Discount",
                    Type = "Employee",
                    Rate = 30,
                    IsRatePercentage = true
                },
                new DiscountType
                {
                    Id = 3,
                    Name = "Loyal Customer Discount",
                    Type = "Customer",
                    Rate = 5,
                    IsRatePercentage = true
                },
                new DiscountType
                {
                    Id = 4,
                    Name = "Price Discount",
                    Type = "Price",
                    Rate = 5,
                    IsRatePercentage = false
                }
            );
        }
    }
}
