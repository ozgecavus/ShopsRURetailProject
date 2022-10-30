using AutoMapper; 
using Microsoft.AspNetCore.Mvc;
using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Entities.DTOs;
using ShopsRUsRetail.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRUs.Controllers
{
    [Route("api/discounts")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public DiscountController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var discounts = await _serviceManager.DiscountService.GetAllDiscounts();
            var discountsDto = _mapper.Map<IEnumerable<DiscountDto>>(discounts);
            return Ok(discountsDto);
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> GetDiscount(string type)
        {
            var discount = await _serviceManager.DiscountService.GetDiscount(type);
            if (discount == null) return NotFound();
            var discountPercentage = _serviceManager.DiscountService.DiscountPercentage(discount);
            if (discountPercentage != null) return Ok(discountPercentage);
            return NotFound(); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountDto discountDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var discountEntity = _mapper.Map<DiscountType>(discountDto);
            await _serviceManager.DiscountService.CreateDiscount(discountEntity);
            return Ok();
        }
    }
}
