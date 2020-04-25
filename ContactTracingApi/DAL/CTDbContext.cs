using Core.Models;
using DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class CTDbContext : DbContext
    {
        public DbSet<DiagnosisKey> DiagnosisKeys { get; set; }
    

        public CTDbContext(DbContextOptions<CTDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new DiagnosisKeyConfiguration());
        } 

    }

}
