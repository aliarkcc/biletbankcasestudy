using BiletBankCaseStudy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Api.Infrastructure.EntityConfiguration
{
    public class FlightEntityTypeConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("Flight");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.HasOne(f => f.DepartureAirport)
               .WithMany(a => a.Flights)
               .HasForeignKey(f => f.DepartureAirportId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.FlightPrices)
               .WithOne(f => f.Flight)
               .HasForeignKey(f => f.FlightId);

            builder.HasOne(f => f.AirlineCompany)
              .WithMany(a => a.Flights)
              .HasForeignKey(f => f.AirlineCompanyId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }

    
}