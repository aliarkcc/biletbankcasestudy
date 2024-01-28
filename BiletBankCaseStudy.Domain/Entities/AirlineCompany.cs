using BiletBankCaseStudy.Core.Persistence.Repositories;

namespace BiletBankCaseStudy.Domain.Entities
{
    public class AirlineCompany : Entity<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
