using BiletBankCaseStudy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Api.Infrastructure.EntityConfiguration
{
    public class FlightPriceEntityTypeConfiguration : IEntityTypeConfiguration<FlightPrice>
    {
        public void Configure(EntityTypeBuilder<FlightPrice> builder)
        {
            builder.ToTable("FlightPrice");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.HasOne(f => f.Flight)
              .WithMany(a => a.FlightPrices)
              .HasForeignKey(f => f.FlightId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }

    
}