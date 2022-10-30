
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
    public class InvoiceServiceTest
    {

        private InvoiceService invoiceService { get; set; }
        private Mock<IInvoiceRepository> mockIInvoiceRepository = new Mock<IInvoiceRepository>();
        private Mock<IDiscountRepository> mockIDiscountRepository = new Mock<IDiscountRepository>();
        private Mock<IStoreTypeRepository> mockIStoreTypeRepository = new Mock<IStoreTypeRepository>();


        public InvoiceServiceTest()
        {
            this.invoiceService = new InvoiceService(mockIInvoiceRepository.Object, mockIDiscountRepository.Object, mockIStoreTypeRepository.Object);

        }



        [Theory]
        [InlineData("ABC123", 535.5)]
        public async void GetInvoice_ShouldBeSame_WhenGivenValue_ReturnSuccess(string billNumber, decimal payableAmount)
        {
            mockIInvoiceRepository.Setup(rep => rep.GetTotalInvoiceAmount(It.IsAny<string>())).ReturnsAsync(new Invoice { PayableAmount = payableAmount });
            var result = await invoiceService.GetInvoice(billNumber);
            Assert.Equal(payableAmount, result.PayableAmount);

        }

        [Fact]
        public async void AddInvoice_ShouldBeCreated_WhenGivenValue_ReturnSuccess()
        {
            var invoice = new Invoice
            {
                TotalAmount = 100,
                StoreTypeId = 2,
                InvoiceNumber = "ABC0000001",
                OrderId = 1,
                DiscountAmount = 10,
                PayableAmount = 90,
                UserId = 1,
                InvoiceDetails = new List<InvoiceDetails> { new InvoiceDetails { ProductId = 1, ProductName = "test", ProductQuantity = 1, ProductCost = 100, ProductPrice = 100 } }

            };



            Invoice actual = null;
            mockIInvoiceRepository.Setup(item => item.GenerateInvoiceForCustomer(It.IsAny<Invoice>()))
                          .Callback(new InvocationAction(i => actual = (Invoice)i.Arguments[0]));

            Invoice expectedInvoice = new Invoice
            {
                TotalAmount = 100,
                StoreTypeId = 2,
                InvoiceNumber = "ABC0000001",
                OrderId = 1,
                DiscountAmount = 10,
                PayableAmount = 90,
                UserId = 1,
                InvoiceDetails = new List<InvoiceDetails> { new InvoiceDetails { ProductId = 1, ProductName = "test", ProductQuantity = 1, ProductCost = 100, ProductPrice = 100 } }

            };

            await invoiceService.GenerateInvoiceForCustomer(invoice);
            Assert.Equal(expectedInvoice.InvoiceNumber, actual.InvoiceNumber);

        }


    }
}

