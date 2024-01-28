using BiletBankCaseStudy.Core.Persistence.Repositories;

namespace BiletBankCaseStudy.Domain.Entities
{

    public class Airport : Entity<Guid>
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string IATA_CODE { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
