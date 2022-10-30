using ShopsRUsRetail.Core.Repositories;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Repository.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        ApplicationContext _context;
        //IDiscountRepository _discount;
        //IInvoiceRepository _invoice;
        //IUserRepository _user;
        //IStoreTypeRepository _storeType;
        public RepositoryManager(ApplicationContext context)
        {
            _context = context;
        }


        //public IDiscountRepository Discount
        //{
        //    get
        //    {
        //        if (_discount == null)
        //            _discount = new DiscountRepository(_context);
        //        return _discount;
        //    }
        //}

        //public IInvoiceRepository Invoice
        //{
        //    get
        //    {
        //        if (_invoice == null)
        //            _invoice = new InvoiceRepository(_context);
        //        return _invoice;
        //    }
        //}

        //public IUserRepository User
        //{
        //    get
        //    {
        //        if (_user == null)
        //            _user = new UserRepository(_context);
        //        return _user;
        //    }
        //}

        //public IStoreTypeRepository StoreType
        //{
        //    get
        //    {
        //        if (_storeType == null)
        //            _storeType = new StoreTypeRepository(_context);
        //        return _storeType;
        //    }
        //}
        ////private bool disposed = false;
        ////protected virtual void Dispose(bool dispose)
        ////{
        ////    if (!this.disposed)
        ////        if (dispose)
        ////            _context.Dispose();
        ////    this.disposed = true;
        ////}
        ////public void Dispose()
        ////{
        ////    Dispose(true);
        ////    GC.SuppressFinalize(this);
        ////}

        public async Task SaveAsync() => await _context.SaveChangesAsync(); 
    }
}
