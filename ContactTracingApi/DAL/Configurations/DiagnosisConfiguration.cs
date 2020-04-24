using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace DAL.Configurations
{
    public class DiagnosisConfiguration : IEntityTypeConfiguration<Diagnosis>
    {
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Date);

            builder
                .ToTable("Diagnosis");
        }

    }
}
