using BiletBankCaseStudy.Application.Services.Repositories;
using BiletBankCaseStudy.Core.Persistence.Repositories;
using BiletBankCaseStudy.Domain.Entities;
using BiletBankCaseStudy.Persistence.Context;

namespace BiletBankCaseStudy.Persistence.Repositories
{
    public class AirportRepository : EfRepositoryBase<Airport, Guid, DatabaseContext>, IAirportRepository
    {
        public AirportRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
