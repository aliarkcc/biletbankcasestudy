using BiletBankCaseStudy.Application.Services.Repositories;
using BiletBankCaseStudy.Core.Persistence.Repositories;
using BiletBankCaseStudy.Domain.Entities;
using BiletBankCaseStudy.Persistence.Context;

namespace BiletBankCaseStudy.Persistence.Repositories
{
    public class AirlineCompanyRepository : EfRepositoryBase<AirlineCompany, Guid, DatabaseContext>, IAirlineCompanyRepository
    {
        public AirlineCompanyRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
