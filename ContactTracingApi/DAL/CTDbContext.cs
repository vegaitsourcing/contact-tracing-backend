using Core.Models;
using DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CTDbContext : DbContext
    {
        public DbSet<HealthUser> HealthUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DiagnosisKey> DiagnosisKeys { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }

        public CTDbContext(DbContextOptions<CTDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new HealthUserConfiguration());
            builder
                .ApplyConfiguration(new UserConfiguration());
            builder
                .ApplyConfiguration(new DiagnosisKeyConfiguration());
            builder
                .ApplyConfiguration(new DiagnosisConfiguration());

            builder.Entity<Diagnosis>()
                   .HasMany(e => e.DiagnosisKeys)
                   .WithOne(c => c.Diagnosis)
                   .HasForeignKey(c => c.DiagnosisId);

            //builder.Entity<DiagnosisKey>()
            //       .HasOne(e => e.Diagnosis)
            //       .WithMany(c => c.DiagnosisKeys);

        } 

    }

}
