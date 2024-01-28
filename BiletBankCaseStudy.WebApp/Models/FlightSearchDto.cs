namespace BiletBankCaseStudy.WebApp.Models
{
    public class FlightSearchDto
    {
        public Guid Id { get; set; }
        public string AirlineCompanyName { get; set; }
        public string DepartureAirportIATA_CODE { get; set; }
        public string DepartureAirportName{ get; set; }
        public string ArrivalAirportIATA_CODE { get; set; }
        public string ArrivalAirportName{ get; set; }
        public DateTime DepartureDate { get; set; }
        public double TotalHours { get; set; }
        public IEnumerable<FlightPriceDto> FlightPrices { get; set; }
    }
}
