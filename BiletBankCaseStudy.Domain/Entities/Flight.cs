using BiletBankCaseStudy.Core.Persistence.Repositories;

namespace BiletBankCaseStudy.Domain.Entities
{
    public class Flight : Entity<Guid>
    {
        public Guid AirlineCompanyId { get; set; }
        public Guid DepartureAirportId { get; set; }
        public Guid ArrivalAirportId { get; set; }
        public DateTime DepartureDate { get; set; }
        public int TotalHours { get; set; }
        public virtual AirlineCompany AirlineCompany { get; set; }
        public virtual Airport DepartureAirport { get; set; }
        public virtual Airport ArrivalAirport { get; set; }
        public virtual ICollection<FlightPrice> FlightPrices { get; set; }
    }
}
