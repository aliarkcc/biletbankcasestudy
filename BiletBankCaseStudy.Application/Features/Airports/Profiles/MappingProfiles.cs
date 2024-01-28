using AutoMapper;
using BiletBankCaseStudy.Application.Features.Airports.Dtos;
using BiletBankCaseStudy.Application.Features.Airports.Models;
using BiletBankCaseStudy.Core.Persistence.Paging;
using BiletBankCaseStudy.Domain.Entities;

namespace BiletBankCaseStudy.Application.Features.Airports.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Airport, AirportDto>().ReverseMap();
            CreateMap<Paginate<Airport>, AirportListModel>().ReverseMap();
        }
    }
}
