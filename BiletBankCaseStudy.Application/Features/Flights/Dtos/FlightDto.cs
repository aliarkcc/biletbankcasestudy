namespace BiletBankCaseStudy.Application.Features.Flights.Dtos
{
    public class FlightDto
    {
        public Guid Id { get; set; }
        public string AirlineCompanyName { get; set; }
        public string LuggageWeight { get; set; }
        public string DepartureAirport { get; set; }
    }
}
