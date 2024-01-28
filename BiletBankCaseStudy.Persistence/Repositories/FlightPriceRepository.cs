using BiletBankCaseStudy.Application.Services.Repositories;
using BiletBankCaseStudy.Core.Persistence.Repositories;
using BiletBankCaseStudy.Domain.Entities;
using BiletBankCaseStudy.Persistence.Context;

namespace BiletBankCaseStudy.Persistence.Repositories
{
    public class FlightPriceRepository : EfRepositoryBase<FlightPrice, Guid, DatabaseContext>, IFlightPriceRepository
    {
        public FlightPriceRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
