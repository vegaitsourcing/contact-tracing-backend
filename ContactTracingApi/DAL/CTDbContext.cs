﻿using Core.Models;
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

        } 

    }

}
