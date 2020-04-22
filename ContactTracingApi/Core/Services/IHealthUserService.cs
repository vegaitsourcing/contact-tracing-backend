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
        Task<HealthUser> RegisterHealthUser(HealthUser newHealthUser);
        Task UpdateHealthUser(HealthUser healthUserToBeUpdated, HealthUser healthUser);
        Task DeleteHealthUser(HealthUser healthUser);

        Task Login(HealthUserDTO healthUserDTO);
    }
}
