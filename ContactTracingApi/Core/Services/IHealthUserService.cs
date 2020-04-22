using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IHealthUserService
    {
        Task<IEnumerable<HealthUser>> GetAllHealthUsers();
        Task<HealthUser> GetHealthUserById(int id);
        Task<HealthUser> RegisterHealthUser(HealthUser newHealthUser, string password);
        Task UpdateHealthUser(HealthUser healthUserToBeUpdated, HealthUser healthUser);
        Task<HealthUser> DeleteHealthUser(int id);
        Task<HealthUser> Login(LoginDTO loginDTO);
    }
}
