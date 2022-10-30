using AutoMapper;
using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Repositories;
using ShopsRUsRetail.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Service.Services
{
    public class DiscountService : IDiscountService
    {

        private readonly IDiscountRepository _repository;

        public DiscountService(IDiscountRepository repository)
        {
            _repository = repository;
        
        }

      
        public async Task<IEnumerable<DiscountType>> GetAllDiscounts()
        {
            var discounts = await _repository.GetAllDiscounts();
            return discounts;
        }


        public async Task<DiscountType> GetDiscount(string type)
        {
            var discount = await _repository.GetDiscountPercentageByType(type);
            return discount;
        }

    
        public async Task<int> CreateDiscount(DiscountType discounttype)
        {
            _repository.CreateDiscountType(discounttype);
            await _repository.SaveAsync();
            return discounttype.Id;
        }

        public string DiscountPercentage(DiscountType discount)
        {
           return _repository.DiscountPercentage(discount);
         
        }


    }
}

