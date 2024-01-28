using BiletBankCaseStudy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Api.Infrastructure.EntityConfiguration
{
    public class AirlineCompanyEntityTypeConfiguration : IEntityTypeConfiguration<AirlineCompany>
    {
        public void Configure(EntityTypeBuilder<AirlineCompany> builder)
        {
            builder.ToTable("AirlineCompany");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.HasMany(a => a.Flights)
               .WithOne(f => f.AirlineCompany)
               .HasForeignKey(f => f.AirlineCompanyId);
        }
    }

    
}