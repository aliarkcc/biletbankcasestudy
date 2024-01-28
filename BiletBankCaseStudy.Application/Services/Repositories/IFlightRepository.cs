﻿using BiletBankCaseStudy.Core.Persistence.Repositories;
using BiletBankCaseStudy.Domain.Entities;

namespace BiletBankCaseStudy.Application.Services.Repositories
{
    public interface IFlightRepository : IAsyncRepository<Flight, Guid>
    {
    }
}