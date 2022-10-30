using ShopsRUsRetail.Core.Repositories;
using ShopsRUsRetail.Core.Services;


namespace ShopsRUsRetail.Service.Services
{
    public class ServiceManager : IServiceManager
    {
        IDiscountRepository _IDiscountRepository;
        IInvoiceRepository _IInvoiceRepository;
        IUserRepository _IUserRepository;
        IStoreTypeRepository _IStoreTypeRepository;

        IDiscountService _DiscountService;
        IUserService _UserService;
        IInvoiceService _InvoiceService;

        public ServiceManager(IDiscountRepository discountRepository, IInvoiceRepository invoiceRepository, IUserRepository userRepository, IStoreTypeRepository storeTypeRepository)
        {
            _IDiscountRepository = discountRepository;
            _IInvoiceRepository = invoiceRepository;
            _IUserRepository = userRepository;
            _IStoreTypeRepository = storeTypeRepository;
        }

        public IDiscountService DiscountService
        {
            get
            {
                if (_DiscountService == null)
                    _DiscountService = new DiscountService(_IDiscountRepository);
                return _DiscountService;
            }
        }

        public IUserService UserService
        {
            get
            {
                if (_UserService == null)
                    _UserService = new UserService(_IUserRepository);
                return _UserService;
            }
        }

        public IInvoiceService InvoiceService
        {
            get
            {
                if (_InvoiceService == null)
                    _InvoiceService = new InvoiceService(_IInvoiceRepository,_IDiscountRepository,_IStoreTypeRepository);
                return _InvoiceService;
            }
        }
    }
}


