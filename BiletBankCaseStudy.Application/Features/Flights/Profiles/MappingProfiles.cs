using AutoMapper;
using BiletBankCaseStudy.Application.Features.Flights.Dtos;
using BiletBankCaseStudy.Core.Persistence.Paging;
using BiletBankCaseStudy.Domain.Entities;

namespace BiletBankCaseStudy.Application.Features.Flights.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Flight, FlightDto>().ReverseMap();
            CreateMap<Paginate<FlightDto>, FlightDto>().ReverseMap();

            CreateMap<Flight, FlightSearchResultDto>()
           .ForMember(dest => dest.AirlineCompanyName, opt => opt.MapFrom(src => src.AirlineCompany.Name))
           .ForMember(dest => dest.DepartureAirportIATA_CODE, opt => opt.MapFrom(src => src.DepartureAirport.IATA_CODE))
           .ForMember(dest => dest.DepartureAirportName, opt => opt.MapFrom(src => src.DepartureAirport.Name))
           .ForMember(dest => dest.ArrivalAirportIATA_CODE, opt => opt.MapFrom(src => src.ArrivalAirport.IATA_CODE))
           .ForMember(dest => dest.ArrivalAirportName, opt => opt.MapFrom(src => src.ArrivalAirport.Name))
           .ForMember(dest => dest.DepartureDate, opt => opt.MapFrom(src => src.DepartureDate))
           .ForMember(dest => dest.FlightPrices, opt => opt.MapFrom(src => src.FlightPrices.Select(fp => new FlightPriceDto
           {
               LuggageWeight = fp.LuggageWeight,
               Features = fp.Features,
               PriceType = fp.PriceType,
               Price = fp.Price,
           })));
        }
    }
}
