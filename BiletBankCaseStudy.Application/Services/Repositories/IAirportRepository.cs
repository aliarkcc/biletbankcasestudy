using BiletBankCaseStudy.Core.Persistence.Repositories;
using BiletBankCaseStudy.Domain.Entities;

namespace BiletBankCaseStudy.Application.Services.Repositories
{
    public interface IAirportRepository : IAsyncRepository<Airport, Guid>
    {
    }
}