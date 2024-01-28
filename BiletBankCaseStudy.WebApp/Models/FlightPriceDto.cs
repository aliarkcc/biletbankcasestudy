using BiletBankCaseStudy.WebApp.Core.Security.Enums;

namespace BiletBankCaseStudy.WebApp.Models
{
    public class FlightPriceDto
    {
        public FligtPriceType PriceType { get; set; }
        public int LuggageWeight { get; set; }
        public string Features { get; set; }
        public double Price { get; set; }
    }
}
