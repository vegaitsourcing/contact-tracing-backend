using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace DAL.Configurations
{
    public class DiagnosisKeyConfiguration : IEntityTypeConfiguration<DiagnosisKey>
    {
        public void Configure(EntityTypeBuilder<DiagnosisKey> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.DailyKey)
                .IsRequired()
                .HasMaxLength(128);

            builder
               .Property(m => m.Date)
               .IsRequired();

            builder
                .ToTable("DiagnosisKeys");
        }
    }
}
