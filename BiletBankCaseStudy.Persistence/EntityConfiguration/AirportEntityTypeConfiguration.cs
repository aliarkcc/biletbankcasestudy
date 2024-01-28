using BiletBankCaseStudy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Api.Infrastructure.EntityConfiguration
{
    public class AirportEntityTypeConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.ToTable("Airport");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasMany(a => a.Flights)
               .WithOne(f => f.DepartureAirport)
               .HasForeignKey(f => f.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}