using AutoMapper;
using BiletBankCaseStudy.Application.Features.Flights.Dtos;
using BiletBankCaseStudy.Application.Features.Flights.Models;
using BiletBankCaseStudy.Application.Services.Repositories;
using BiletBankCaseStudy.Core.Application.Requests;
using BiletBankCaseStudy.Core.Utilities.Messages;
using BiletBankCaseStudy.Core.Utilities.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BiletBankCaseStudy.Application.Features.Flights.Queries.GetList
{
    public class GetListFlightsSearchQuery : IRequest<ApiDataResponse<FlightSearchListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public FlightSearchModel SearchModel { get; set; }

        public class GetListFlightsSearchQueryHandler : IRequestHandler<GetListFlightsSearchQuery, ApiDataResponse<FlightSearchListModel>>
        {
            private readonly IAirportRepository _airportRepository;
            private readonly IFlightRepository _flightRepository;
            private readonly IMapper _mapper;

            public GetListFlightsSearchQueryHandler(IFlightRepository flightRepository, IMapper mapper, IAirportRepository airportRepository)
            {
                _flightRepository = flightRepository;
                _mapper = mapper;
                _airportRepository = airportRepository;
            }

            public async Task<ApiDataResponse<FlightSearchListModel>> Handle(GetListFlightsSearchQuery request, CancellationToken cancellationToken)
            {
                //request.SearchModel.DepartureAirportCode = "MTT";
                //request.SearchModel.ArrivalAirportCode = "YZT";
                request.SearchModel.DepartureDate = DateTime.Parse("2024-01-26T18:46:25.066Z");
                request.SearchModel.ArrivalDate = DateTime.Parse("2024-01-28T18:46:25.066Z");

                var departureAirport = await _airportRepository.GetAsync(predicate: x => x.IATA_CODE == request.SearchModel.DepartureAirportCode, cancellationToken: cancellationToken);

                if (departureAirport is null) return new ErrorApiDataResponse<FlightSearchListModel>(data: null, message: "Departure Airport Not Found!".ToString(), resultCount: 0);


                var arrivalAirport = await _airportRepository.GetAsync(predicate: x => x.IATA_CODE == request.SearchModel.ArrivalAirportCode, cancellationToken: cancellationToken);

                if (arrivalAirport is null) return new ErrorApiDataResponse<FlightSearchListModel>(data: null, message: "Arrival Airport Not Found!".ToString(), resultCount: 0);

                var departureDate = request.SearchModel.DepartureDate.Date;
                var endDepartureDate = departureDate.AddDays(1).AddTicks(-1);

                var flights = await _flightRepository.GetListAsync(
                    predicate: x => x.DepartureAirportId == departureAirport.Id && x.ArrivalAirportId == arrivalAirport.Id && x.DepartureDate >= departureDate
                    && x.DepartureDate <= endDepartureDate,
                    include: i => i.Include(i => i.DepartureAirport).Include(i => i.ArrivalAirport).Include(i => i.AirlineCompany).Include(i=>i.FlightPrices),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                if (!flights.Items.Any()) return new ErrorApiDataResponse<FlightSearchListModel>(data: null, message: "Flight Not Found!".ToString(), resultCount: 0);


                FlightSearchListModel flightSearchListModel = new FlightSearchListModel();
                flightSearchListModel.DepartureItems = _mapper.Map<IList<FlightSearchResultDto>>(flights.Items);

                if (request.SearchModel.ArrivalDate != default(DateTime))
                {
                    var arrivalDate = request.SearchModel.ArrivalDate.Date;
                    var endArrivalDate = arrivalDate.AddDays(1).AddTicks(-1);

                    flights = await _flightRepository.GetListAsync(
                        predicate: x =>
                        flights.Items.Select(x => x.DepartureAirportId).Contains(x.ArrivalAirportId) &&
                        x.DepartureAirportId == arrivalAirport.Id &&
                        x.DepartureDate >= arrivalDate &&
                        x.DepartureDate <= endArrivalDate,
                        include: i => i.Include(i => i.DepartureAirport).Include(i => i.ArrivalAirport).Include(i => i.AirlineCompany).Include(i => i.FlightPrices),
                        index: request.PageRequest.Page, size: request.PageRequest.PageSize
                    );

                    if (!flights.Items.Any()) return new ErrorApiDataResponse<FlightSearchListModel>(data: null, message: "Flight Not Found!".ToString(), resultCount: 0);

                    flightSearchListModel.ArrivalItems = _mapper.Map<IList<FlightSearchResultDto>>(flights.Items);
                }

                return new SuccessApiDataResponse<FlightSearchListModel>(data: flightSearchListModel, message: ResultCodes.HTTP_OK.ToString(), resultCount: flightSearchListModel.ArrivalItems.Count);
            }
        }
    }
}
