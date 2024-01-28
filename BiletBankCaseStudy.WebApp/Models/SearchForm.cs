namespace BiletBankCaseStudy.WebApp.Models
{
    public class SearchForm
    {
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
