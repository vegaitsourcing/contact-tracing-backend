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
                .Property(m => m.UserId);

            builder
                .Property(m => m.Sent);

            builder
                .Property(m => m.Confirmed);

            builder
                .ToTable("Diagnosis");
        }

    }
}
