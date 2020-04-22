using Core;
using Core.Repositories;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CTDbContext _context;
        private HealthUserRepository _healthUserRepository;

        public UnitOfWork(CTDbContext context)
        {
            this._context = context;
        }

        public IHealthUserRepository HealthUsers => _healthUserRepository = _healthUserRepository ?? new HealthUserRepository(_context);

       
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
