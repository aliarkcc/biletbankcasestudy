namespace BiletBankCaseStudy.WebApp.Models
{
    public class FlightSearchListModel
    {
        public IList<FlightSearchDto> DepartureItems { get; set; }
        public IList<FlightSearchDto> ArrivalItems { get; set; }
    }
}
