using AutoMapper;
using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Entities.DTOs;


namespace ShopsRUsRetail.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Resource Maps
            CreateMap<Users, CustomerUsersDto>()
                .ForMember(cdto => cdto.FullName,
                copt => copt.MapFrom(c => string.Join(" ", c.LastName, c.MiddleName, c.FirstName)))
                .ForMember(cdto => cdto.JoinedIn, 
                opt => opt.MapFrom(c => c.DateCreated.Date.ToLongDateString()));
                
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<DiscountType, DiscountDto>();

            // Create maps
            CreateMap<CreateCustomerUserDto, Users>();
            CreateMap<CreateDiscountDto, DiscountType>();
            CreateMap<CreateInvoiceDto, Invoice>();
            
        }
    }
}
