using AutoMapper;
using BiletBankCaseStudy.Application.Features.Airports.Models;
using BiletBankCaseStudy.Application.Services.Repositories;
using BiletBankCaseStudy.Core.Application.Requests;
using BiletBankCaseStudy.Core.Persistence.Paging;
using BiletBankCaseStudy.Core.Utilities.Responses;
using BiletBankCaseStudy.Domain.Entities;
using MediatR;

namespace BiletBankCaseStudy.Application.Features.Airports.Queries.GetList
{
    public class GetListAirportsQuery : IRequest<ApiDataResponse<AirportListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProductsQueryHandler : IRequestHandler<GetListAirportsQuery, ApiDataResponse<AirportListModel>>
        {
            private readonly IAirportRepository _airportRepository;
            private readonly IMapper _mapper;

            public GetListProductsQueryHandler(IAirportRepository airportRepository, IMapper mapper)
            {
                _airportRepository = airportRepository;
                _mapper = mapper;
            }

            public async Task<ApiDataResponse<AirportListModel>> Handle(GetListAirportsQuery request, CancellationToken cancellationToken)
            {
                Paginate<Airport> airports = await _airportRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                airports.Items = airports.Items.OrderBy(x => x.Name).ToList();

                AirportListModel airportListModel = _mapper.Map<AirportListModel>(airports);

                if (airportListModel.Items.Any())
                    return new SuccessApiDataResponse<AirportListModel>(data: airportListModel,"");

                return new ErrorApiDataResponse<AirportListModel>(data: null,"Airport List Not Found!");
            }
        }
    }
}
