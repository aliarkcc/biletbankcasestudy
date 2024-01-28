using BiletBankCaseStudy.Core.Persistence.Repositories;
using BiletBankCaseStudy.Core.Security.Enums;

namespace BiletBankCaseStudy.Domain.Entities
{
    public class FlightPrice : Entity<Guid>
    {
        public int LuggageWeight { get; set; }
        public double Price { get; set; }
        public FligtPriceType PriceType { get; set; }
        public string Features { get; set; }
        public Guid FlightId { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
