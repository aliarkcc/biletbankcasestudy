using BiletBankCaseStudy.Domain.Entities;
using CatalogService.Api.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BiletBankCaseStudy.Persistence.Context
{
    public class DatabaseContext : DbContext
    {
        IConfiguration Configuration { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<AirlineCompany> AirlineCompanies { get; set; }
        public DbSet<FlightPrice> FlightPrices { get; set; }

        public DatabaseContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AirportEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AirlineCompanyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FlightPriceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FlightEntityTypeConfiguration());
        }
    }
}
