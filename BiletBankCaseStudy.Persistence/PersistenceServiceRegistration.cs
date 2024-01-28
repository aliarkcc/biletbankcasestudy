using BiletBankCaseStudy.Application.Services.Repositories;
using BiletBankCaseStudy.Persistence.Context;
using BiletBankCaseStudy.Persistence.Context.SeedData;
using BiletBankCaseStudy.Persistence.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BiletBankCaseStudy.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(configuration["ConnectionString"]));

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    try
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                        dbContext.Database.Migrate();

                        var env = serviceProvider.GetService<IWebHostEnvironment>();
                        var logger = serviceProvider.GetService<ILogger<DatabaseContextSeed>>();

                        new DatabaseContextSeed()
                        .SeedAsync(dbContext, env, logger)
                        .Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Database update Error: " + ex.Message);
                    }
                }
            }

            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<IAirlineCompanyRepository, AirlineCompanyRepository>();
            services.AddScoped<IFlightPriceRepository, FlightPriceRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();

            return services;
        }
    }
}
