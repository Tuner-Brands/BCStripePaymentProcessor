using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe;

namespace BCStripeSync
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<D365BCConnectorAPIGear.Customer, Stripe.Customer>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => (long)src.BalanceDue))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.CurrencyCode))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Website)) // Assuming website as a description
                .ForMember(dest => dest.Created,
                    opt => opt.MapFrom(src =>
                        src.LastModifiedDateTime)) // Assuming LastModifiedDateTime as created date
                .ForMember(dest => dest.TaxExempt,
                    opt => opt.MapFrom(src => src.TaxLiable ? "none" : "exempt")) // Mapping boolean to string
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Line1 = src.AddressLine1,
                    Line2 = src.AddressLine2,
                    City = src.City,
                    State = src.State,
                    Country = src.Country,
                    PostalCode = src.PostalCode
                }))
                ;
        }
    }
}
