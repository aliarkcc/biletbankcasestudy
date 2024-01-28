using BiletBankCaseStudy.Application.Features.Flights.Dtos;

namespace BiletBankCaseStudy.Application.Features.Flights.Models
{
    public class FlightSearchListModel
    {
        public IList<FlightSearchResultDto> DepartureItems { get; set; }
        public IList<FlightSearchResultDto> ArrivalItems { get; set; }
    }

}
