using ShopsRUsRetail.Core.Entities;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Core.Repositories
{
    public interface IInvoiceRepository : IRepositoryManager
    {
        Task<Invoice> GetTotalInvoiceAmount(string billNumber);
        void GenerateInvoiceForCustomer(Invoice invoice);
    }
}
