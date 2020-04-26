using VegaIT.Core.Models;
using VegaIT.DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace VegaIT.DAL
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
