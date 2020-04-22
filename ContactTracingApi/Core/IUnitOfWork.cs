using Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        IHealthUserRepository HealthUsers { get; }
        Task<int> CommitAsync();
    }
}
