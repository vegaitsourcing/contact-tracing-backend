using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class HealthUserRepository : Repository<HealthUser>, IHealthUserRepository
    {
        public HealthUserRepository(CTDbContext context)
            : base(context)
        { }

        
    }

}
