using Core;
using Core.DTOs;
using Core.Helpers;
using Core.Models;
using Core.Services;
using DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class HealthUserService : IHealthUserService
    {
        private readonly CTDbContext _context; 
        public HealthUserService(CTDbContext context )
        {
            _context = context;
        }

        public async Task<HealthUser> RegisterHealthUser(HealthUser newHealthUser, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.HealthUsers.Any(x => x.Email == newHealthUser.Email))
                throw new AppException("Email \"" + newHealthUser.Email + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            Crypto.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            newHealthUser.Password = passwordHash;
            newHealthUser.PasswordSalt = passwordSalt;


            await _context.HealthUsers
                .AddAsync(newHealthUser);

            await _context.SaveChangesAsync();

            return newHealthUser;
        }

        public async Task<IEnumerable<HealthUser>> GetAllHealthUsers()
        {
            return await _context.HealthUsers.ToListAsync();
        }
        public async Task<HealthUser> GetHealthUserById(int id)
        {
            return await _context.HealthUsers.FindAsync(id);
        }
       
        public async Task UpdateHealthUser(HealthUser healthUserToBeUpdated, HealthUser healthUser)
        {
            healthUserToBeUpdated.Name = healthUser.Name;

            await _context.SaveChangesAsync();
        }
        public async Task<HealthUser> DeleteHealthUser(int id)
        {
            
            var healthUser = await _context.HealthUsers.FindAsync(id);

            _context.HealthUsers.Remove(healthUser);

            await _context.SaveChangesAsync();

            return healthUser;
        }

        public async Task<HealthUser> Login(LoginDTO loginDTO)
        {
            if (string.IsNullOrEmpty(loginDTO.Email) || string.IsNullOrEmpty(loginDTO.Password))
                return null;

            var user = await _context.HealthUsers.SingleOrDefaultAsync(x => x.Email == loginDTO.Email);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!Crypto.VerifyPasswordHash(loginDTO.Password, user.Password, user.PasswordSalt))
                return null;

            // authentication successful
            return user;

        }

       

    }
}
