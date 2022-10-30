
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
    public class DiscountServiceTest
    {

     
        private DiscountService discountService { get; set; }
        private Mock<IDiscountRepository> mockIDiscountRepository = new Mock<IDiscountRepository>();

     

        public DiscountServiceTest()
        {
            this.discountService = new DiscountService(mockIDiscountRepository.Object);

        }

        [Theory]
        [InlineData("Loyal Customer Discount", "Customer", 5,true, "Loyal Customer Discount", "Customer", 5, true)]
        public async void AddDiscount_ShouldBeCreated_WhenGivenValue_ReturnSuccess(string actualname, string actualtype, decimal actualrate,bool actualisRatePercentage
                                                                                        , string expectedname, string expectedtype, decimal expectedrate, bool expectedRatePercentage)
        {
            var discount = new DiscountType
            {
                Name = actualname,
                Type = actualtype,
                Rate = actualrate,
                IsRatePercentage = actualisRatePercentage,
            };

            DiscountType actual = null;
            mockIDiscountRepository.Setup(item => item.CreateDiscountType(It.IsAny<DiscountType>()))
                      .Callback(new InvocationAction(i => actual = (DiscountType)i.Arguments[0]));

            DiscountType expectedDiscount = new DiscountType
            {
                Name = expectedname,
                Type = expectedtype,
                Rate = expectedrate,
                IsRatePercentage = expectedRatePercentage,
            };

            await discountService.CreateDiscount(discount);
            Assert.Equal(expectedDiscount.Name, actual.Name);
        }

        //[Fact]
        //public async void AddDiscount_Failed_WhenGivenNullValue_ReturnError()
        //{
        //    try
        //    {
        //        int userId = await discountService.CreateDiscount(null);
        //        Assert.Equal(1, 0);
        //    }
        //    catch (Exception)
        //    {

        //        Assert.False(false);
        //    }

        //}

        [Theory]
        [InlineData("Customer",5,5)]
        public async void GetDiscountPercantage_ShouldBeSame_WhenGivenValue_ReturnSuccess(string discountType, int actualPercantage,int expectedPercantage)
        {
            mockIDiscountRepository.Setup(rep => rep.GetDiscountPercentageByType(It.IsAny<string>())).ReturnsAsync(new DiscountType { Type = discountType,Rate = actualPercantage });
            DiscountType result = await discountService.GetDiscount(discountType);
            Assert.Equal(expectedPercantage, result.Rate);

        }

    }
}

