using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace DAL.Configurations
{
    public class HealthUserConfiguration : IEntityTypeConfiguration<HealthUser>
    {
        public void Configure(EntityTypeBuilder<HealthUser> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .HasIndex(m => m.Email).IsUnique();

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Password)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .ToTable("HealthUsers");
        }
    }
}
