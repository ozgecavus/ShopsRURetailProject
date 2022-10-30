using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace ShopsRURetail.Test
{

    public class InvoiceIntegrationTest : IntegrationTest
    {
        Random rnd = new Random();

        #region Apply Percantage and Price Discount
        [Theory]
        [InlineData(2, 100, 90)]
        public async Task CreateCustomerInvoice_ShouldBeApplyPercantageAndPriceDiscount_WhenGivenValidInvoice_ReturnSuccess(int StoreTypeId, decimal TotalInvoiceAmountBeforeDiscount, decimal expectedPayableAmount)
        {


            CreateInvoiceDto dto = new CreateInvoiceDto { UserId = 1, StoreTypeId = StoreTypeId, TotalAmount = TotalInvoiceAmountBeforeDiscount, OrderId = 1, InvoiceNumber = "TEST" + rnd.Next(100000000, 999999999).ToString(), InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = TotalInvoiceAmountBeforeDiscount, ProductQuantity = 1, ProductPrice = TotalInvoiceAmountBeforeDiscount } } };


            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Invoice.CreateInvoice, dto);
            decimal? invoicePayableAmount = await response.Content.ReadFromJsonAsync<Decimal>();

            response.EnsureSuccessStatusCode();
            Assert.NotNull(invoicePayableAmount);
            Assert.Equal(expectedPayableAmount, invoicePayableAmount);
        }

        [Theory]
        [InlineData(2, 100, 85.0)]
        public async Task CreateAffiliateInvoice_ShouldBeApplyPercantageAndPriceDiscount_WhenGivenValidInvoice_ReturnSuccess(int StoreTypeId, decimal TotalInvoiceAmountBeforeDiscount, decimal expectedPayableAmount)
        {

            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Invoice.CreateInvoice, new CreateInvoiceDto { UserId = 2, StoreTypeId = StoreTypeId, TotalAmount = TotalInvoiceAmountBeforeDiscount, OrderId = 1, InvoiceNumber = "TEST" + rnd.Next(100000000, 999999999).ToString(), InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = TotalInvoiceAmountBeforeDiscount, ProductQuantity = 1, ProductPrice = TotalInvoiceAmountBeforeDiscount } } });
            decimal? invoicePayableAmount = await response.Content.ReadFromJsonAsync<Decimal>();

            response.EnsureSuccessStatusCode();
            Assert.NotNull(invoicePayableAmount);
            Assert.Equal(expectedPayableAmount, invoicePayableAmount);
        }

        [Theory]
        [InlineData(2, 100, 65.0)]
        public async Task CreateEmployeeInvoice_ShouldBeApplyPercantageAndPriceDiscount_WhenGivenValidInvoice_ReturnSuccess(int StoreTypeId, decimal TotalInvoiceAmountBeforeDiscount, decimal expectedPayableAmount)
        {

            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Invoice.CreateInvoice, new CreateInvoiceDto { UserId = 3, StoreTypeId = StoreTypeId, TotalAmount = TotalInvoiceAmountBeforeDiscount, OrderId = 1, InvoiceNumber = "TEST" + rnd.Next(100000000, 999999999).ToString(), InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = TotalInvoiceAmountBeforeDiscount, ProductQuantity = 1, ProductPrice = TotalInvoiceAmountBeforeDiscount } } });
            decimal? invoicePayableAmount = await response.Content.ReadFromJsonAsync<Decimal>();

            response.EnsureSuccessStatusCode();
            Assert.NotNull(invoicePayableAmount);
            Assert.Equal(expectedPayableAmount, invoicePayableAmount);
        }

        #endregion

        #region Apply Only Product Price Discount


        [Theory]
        [InlineData(1, 100, 95.0)]
        public async Task CreateCustomerGroceryInvoice_ShouldBeApplyOnlyPriceDiscount_WhenGivenValidInvoice_ReturnSuccess(int StoreTypeId, decimal TotalInvoiceAmountBeforeDiscount, decimal expectedPayableAmount)
        {

            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Invoice.CreateInvoice, new CreateInvoiceDto { UserId = 1, StoreTypeId = StoreTypeId, TotalAmount = TotalInvoiceAmountBeforeDiscount, OrderId = 1, InvoiceNumber = "TEST" + rnd.Next(100000000, 999999999).ToString(), InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = TotalInvoiceAmountBeforeDiscount, ProductQuantity = 1, ProductPrice = TotalInvoiceAmountBeforeDiscount } } });
            decimal? invoicePayableAmount = await response.Content.ReadFromJsonAsync<Decimal>();

            response.EnsureSuccessStatusCode();
            Assert.NotNull(invoicePayableAmount);
            Assert.Equal(expectedPayableAmount, invoicePayableAmount);
        }

        [Theory]
        [InlineData(1, 100, 95.0)]
        public async Task CreateAffiliateGorceryInvoice_ShouldBeApplyOnlyPriceDiscount_WhenGivenValidInvoice_ReturnSuccess(int StoreTypeId, decimal TotalInvoiceAmountBeforeDiscount, decimal expectedPayableAmount)
        {

            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Invoice.CreateInvoice, new CreateInvoiceDto { UserId = 2, StoreTypeId = StoreTypeId, TotalAmount = TotalInvoiceAmountBeforeDiscount, OrderId = 1, InvoiceNumber = "TEST" + rnd.Next(100000000, 999999999).ToString(), InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = TotalInvoiceAmountBeforeDiscount, ProductQuantity = 1, ProductPrice = TotalInvoiceAmountBeforeDiscount } } });
            decimal? invoicePayableAmount = await response.Content.ReadFromJsonAsync<Decimal>();

            response.EnsureSuccessStatusCode();
            Assert.NotNull(invoicePayableAmount);
            Assert.Equal(expectedPayableAmount, invoicePayableAmount);
        }

        [Theory]
        [InlineData(1, 100, 95.0)]
        public async Task CreateEmployeeGroceryInvoice_ShouldBeApplyOnlyPriceDiscount_WhenGivenValidInvoice_ReturnSuccess(int StoreTypeId, decimal TotalInvoiceAmountBeforeDiscount, decimal expectedPayableAmount)
        {

            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Invoice.CreateInvoice, new CreateInvoiceDto { UserId = 3, StoreTypeId = StoreTypeId, TotalAmount = TotalInvoiceAmountBeforeDiscount, OrderId = 1, InvoiceNumber = "TEST" + rnd.Next(100000000, 999999999).ToString(), InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = TotalInvoiceAmountBeforeDiscount, ProductQuantity = 1, ProductPrice = TotalInvoiceAmountBeforeDiscount } } });
            decimal? invoicePayableAmount = await response.Content.ReadFromJsonAsync<Decimal>();

            response.EnsureSuccessStatusCode();
            Assert.NotNull(invoicePayableAmount);
            Assert.Equal(expectedPayableAmount, invoicePayableAmount);
        }


        #endregion





        #region Apply Only Percantage Discount

        [Theory]
        [InlineData(2, 200, 180)]
        public async Task CreateCustomerInvoice_ShouldBeApplyOnlyPercantageDiscount_WhenGivenValidInvoice_ReturnSuccess(int StoreTypeId, decimal TotalInvoiceAmountBeforeDiscount, decimal expectedPayableAmount)
        {

            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Invoice.CreateInvoice, new CreateInvoiceDto { UserId = 1, StoreTypeId = StoreTypeId, TotalAmount = TotalInvoiceAmountBeforeDiscount, OrderId = 1, InvoiceNumber = "TEST" + rnd.Next(100000000, 999999999).ToString(), InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = TotalInvoiceAmountBeforeDiscount, ProductQuantity = 1, ProductPrice = TotalInvoiceAmountBeforeDiscount } } });
            decimal? invoicePayableAmount = await response.Content.ReadFromJsonAsync<Decimal>();

            response.EnsureSuccessStatusCode();
            Assert.NotNull(invoicePayableAmount);
            Assert.Equal(expectedPayableAmount, invoicePayableAmount);
        }

        [Theory]
        [InlineData(2, 200, 170)]
        public async Task CreateAffiliateInvoice_ShouldBeApplyOnlyPercantageDiscount_WhenGivenValidInvoice_ReturnSuccess(int StoreTypeId, decimal TotalInvoiceAmountBeforeDiscount, decimal expectedPayableAmount)
        {

            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Invoice.CreateInvoice, new CreateInvoiceDto { UserId = 2, StoreTypeId = StoreTypeId, TotalAmount = TotalInvoiceAmountBeforeDiscount, OrderId = 1, InvoiceNumber = "TEST" + rnd.Next(100000000, 999999999).ToString(), InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = TotalInvoiceAmountBeforeDiscount, ProductQuantity = 1, ProductPrice = TotalInvoiceAmountBeforeDiscount } } });
            decimal? invoicePayableAmount = await response.Content.ReadFromJsonAsync<Decimal>();

            response.EnsureSuccessStatusCode();
            Assert.NotNull(invoicePayableAmount);
            Assert.Equal(expectedPayableAmount, invoicePayableAmount);
        }

        [Theory]
        [InlineData(2, 200, 130)]
        public async Task CreateEmployeeInvoice_ShouldBeApplyOnlyPercantageDiscount_WhenGivenValidInvoice_ReturnSuccess(int StoreTypeId, decimal TotalInvoiceAmountBeforeDiscount, decimal expectedPayableAmount)
        {

            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Invoice.CreateInvoice, new CreateInvoiceDto { UserId = 3, StoreTypeId = StoreTypeId, TotalAmount = TotalInvoiceAmountBeforeDiscount, OrderId = 1, InvoiceNumber = "TEST" + rnd.Next(100000000, 999999999).ToString(), InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = TotalInvoiceAmountBeforeDiscount, ProductQuantity = 1, ProductPrice = TotalInvoiceAmountBeforeDiscount } } });
            decimal? invoicePayableAmount = await response.Content.ReadFromJsonAsync<Decimal>();

            response.EnsureSuccessStatusCode();
            Assert.NotNull(invoicePayableAmount);
            Assert.Equal(expectedPayableAmount, invoicePayableAmount);
        }


        #endregion


        #region Apply Any Discount
        [Theory]
        [InlineData(1, 90, 90)]
        public async Task CreateCustomerGroceryInvoice_ShouldBeApplyAnyDiscount_WhenGivenValidInvoice_ReturnSuccess(int StoreTypeId, decimal TotalInvoiceAmountBeforeDiscount, decimal expectedPayableAmount)
        {

            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Invoice.CreateInvoice, new CreateInvoiceDto { UserId = 1, StoreTypeId = StoreTypeId, TotalAmount = TotalInvoiceAmountBeforeDiscount, OrderId = 1, InvoiceNumber = "TEST" + rnd.Next(100000000, 999999999).ToString(), InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = TotalInvoiceAmountBeforeDiscount, ProductQuantity = 1, ProductPrice = TotalInvoiceAmountBeforeDiscount } } });
            decimal? invoicePayableAmount = await response.Content.ReadFromJsonAsync<Decimal>();

            response.EnsureSuccessStatusCode();
            Assert.NotNull(invoicePayableAmount);
            Assert.Equal(expectedPayableAmount, invoicePayableAmount);
        }

        [Theory]
        [InlineData(1, 90, 90)]
        public async Task CreateAffiliateGorceryInvoice_ShouldBeApplyAnyDiscount_WhenGivenValidInvoice_ReturnSuccess(int StoreTypeId, decimal TotalInvoiceAmountBeforeDiscount, decimal expectedPayableAmount)
        {

            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Invoice.CreateInvoice, new CreateInvoiceDto { UserId = 2, StoreTypeId = StoreTypeId, TotalAmount = TotalInvoiceAmountBeforeDiscount, OrderId = 1, InvoiceNumber = "TEST" + rnd.Next(100000000, 999999999).ToString(), InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = TotalInvoiceAmountBeforeDiscount, ProductQuantity = 1, ProductPrice = TotalInvoiceAmountBeforeDiscount } } });
            decimal? invoicePayableAmount = await response.Content.ReadFromJsonAsync<Decimal>();

            response.EnsureSuccessStatusCode();
            Assert.NotNull(invoicePayableAmount);
            Assert.Equal(expectedPayableAmount, invoicePayableAmount);
        }

        [Theory]
        [InlineData(1, 90, 90)]
        public async Task CreateEmployeeGroceryInvoice_ShouldBeApplyAnyDiscount_WhenGivenValidInvoice_ReturnSuccess(int StoreTypeId, decimal TotalInvoiceAmountBeforeDiscount, decimal expectedPayableAmount)
        {

            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Invoice.CreateInvoice, new CreateInvoiceDto { UserId = 3, StoreTypeId = StoreTypeId, TotalAmount = TotalInvoiceAmountBeforeDiscount, OrderId = 1, InvoiceNumber = "TEST" + rnd.Next(100000000, 999999999).ToString(), InvoiceDetails = new List<InvoiceDetails>() { new InvoiceDetails { ProductName = "test", ProductCost = TotalInvoiceAmountBeforeDiscount, ProductQuantity = 1, ProductPrice = TotalInvoiceAmountBeforeDiscount } } });
            decimal? invoicePayableAmount = await response.Content.ReadFromJsonAsync<Decimal>();

            response.EnsureSuccessStatusCode();
            Assert.NotNull(invoicePayableAmount);
            Assert.Equal(expectedPayableAmount, invoicePayableAmount);
        }



        #endregion

    }

}

