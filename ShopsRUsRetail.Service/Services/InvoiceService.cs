using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Entities.DTOs;
using ShopsRUsRetail.Core.Repositories;
using ShopsRUsRetail.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Service.Services
{
    public class InvoiceService : IInvoiceService
    {

        private readonly IInvoiceRepository _IRepositoryManager;
        private readonly IDiscountRepository _IDiscountRepository;
        private readonly IStoreTypeRepository _IStoreTypeRepository;

        public InvoiceService(IInvoiceRepository repositoryManager, IDiscountRepository _discountRepository, IStoreTypeRepository storeTypeRepository)
        {
            _IRepositoryManager = repositoryManager;
            _IDiscountRepository = _discountRepository;
            _IStoreTypeRepository = storeTypeRepository;
        }

        public async Task GenerateInvoiceForCustomer(Invoice invoice)
        {
            _IRepositoryManager.GenerateInvoiceForCustomer( invoice);
            await _IRepositoryManager.SaveAsync();
        }
        public async Task<Invoice> GetInvoice(string billNumber)
        {
            var invoice = await _IRepositoryManager.GetTotalInvoiceAmount(billNumber);
            return invoice;
        }
        public async Task<decimal> ApplyDiscount(CreateInvoiceDto invoiceDto, string userType)
        {
            decimal totalDiscount = 0.0m;
            decimal PercantegeDiscountAmount = 0.0m;
            decimal PriceDiscountAmount = 0.0m;
            DiscountType _PriceDiscount = null;



            var storeTypes = await _IStoreTypeRepository.GetStoreTypes();


            var storeType = storeTypes.Where(x => x.Id == invoiceDto.StoreTypeId).ToList().FirstOrDefault();

            var discounts = await _IDiscountRepository.GetAllDiscounts();

            if (storeType == null || storeType.IsPercantageDiscount == 1)
            {

                var PercantageRateDiscount = discounts.Where(x => x.Type == userType & x.IsRatePercentage == true).ToList().FirstOrDefault();
                if (PercantageRateDiscount != null)
                    PercantegeDiscountAmount = invoiceDto.TotalAmount * (PercantageRateDiscount.Rate / 100);

            }

            _PriceDiscount = discounts.Where(x => x.IsRatePercentage == false).ToList().FirstOrDefault();

            if (_PriceDiscount != null)
            {

                foreach (var detail in invoiceDto.InvoiceDetails)
                {
                    int PerProductDiscountAmount = 0;
                    if (detail.ProductCost >= 100)
                    {
                        int countOfProductDiscount = (int)(detail.ProductCost / 100);
                        for (int i = 0; i < countOfProductDiscount; i++)
                        {
                            PerProductDiscountAmount += (int)_PriceDiscount.Rate;
                            PriceDiscountAmount += _PriceDiscount.Rate;
                        }


                    }

                    detail.ProductDiscountPrice = PerProductDiscountAmount;
                    detail.ProductPayableCost = detail.ProductCost - PerProductDiscountAmount;
                }

            }

            totalDiscount += PercantegeDiscountAmount;
            totalDiscount += PriceDiscountAmount;

            invoiceDto.PayableAmount = invoiceDto.TotalAmount - totalDiscount;
            invoiceDto.DiscountAmount = totalDiscount;

            return totalDiscount;
        }


    }
}
