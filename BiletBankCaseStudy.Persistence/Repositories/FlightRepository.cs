using BiletBankCaseStudy.Application.Services.Repositories;
using BiletBankCaseStudy.Core.Persistence.Repositories;
using BiletBankCaseStudy.Domain.Entities;
using BiletBankCaseStudy.Persistence.Context;

namespace BiletBankCaseStudy.Persistence.Repositories
{
    public class FlightRepository : EfRepositoryBase<Flight, Guid, DatabaseContext>, IFlightRepository
    {
        public FlightRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
