using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Entities.DTOs;
using ShopsRUsRetail.Core.Services;
using System.Threading.Tasks;

namespace ShopsRUs.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public InvoiceController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        [HttpGet("{billNumber}")]
        public async Task<IActionResult> GetInvoice(string billNumber)
        {
            if (billNumber == null) return BadRequest();
            var invoice = await _serviceManager.InvoiceService.GetInvoice(billNumber);
            if (invoice == null) return NotFound();
            var invoiceDto = _mapper.Map<InvoiceDto>(invoice);
            return Ok(invoiceDto.PayableAmount);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceDto invoiceDto)
        {
            var user = await _serviceManager.UserService.GetUserById(invoiceDto.UserId);
            if (user == null) return NotFound();

            
            await _serviceManager.InvoiceService.ApplyDiscount(invoiceDto, user.UserType);

         
            var invoiceEntity = _mapper.Map<Invoice>(invoiceDto); invoiceEntity.UserId = invoiceDto.UserId;


            await _serviceManager.InvoiceService.GenerateInvoiceForCustomer(invoiceEntity);
            return Ok(invoiceDto.PayableAmount);
        }


    }
}
