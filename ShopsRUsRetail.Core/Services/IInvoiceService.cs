using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Entities.DTOs;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Core.Services
{
    public interface IInvoiceService
    {
        Task<Invoice> GetInvoice(string billNumber);
        Task GenerateInvoiceForCustomer(Invoice invoice);
        Task<decimal> ApplyDiscount(CreateInvoiceDto invoiceDto, string userType);
    }
}
