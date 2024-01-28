namespace BiletBankCaseStudy.Application.Features.Flights.Models
{
    public class FlightSearchModel
    {
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
