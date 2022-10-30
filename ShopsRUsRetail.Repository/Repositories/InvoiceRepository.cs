using Microsoft.EntityFrameworkCore;
using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Repositories;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Repository.Repositories
{
    public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationContext context) :base(context) { }

        public void GenerateInvoiceForCustomer(Invoice invoice)
        {
            Create(invoice);
      
        }

        public async Task<Invoice> GetTotalInvoiceAmount(string billNumber) =>
             await FindByCondition(i => i.InvoiceNumber.Equals(billNumber),
                false).SingleOrDefaultAsync();
    }
}
