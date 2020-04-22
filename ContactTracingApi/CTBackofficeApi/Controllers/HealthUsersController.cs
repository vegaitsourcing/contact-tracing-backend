using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using DAL;
using Core.Services;
using AutoMapper;
using Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Core.DTOs;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace CTBackofficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HealthUsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IHealthUserService _healthUserService;
        private readonly AppSettings _appSettings;

        public HealthUsersController(IMapper mapper, IOptions<AppSettings> appSettings, IHealthUserService healthUserService)
        {
            _healthUserService = healthUserService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        // GET: api/HealthUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthUser>>> GetHealthUsers()
        {
            return Ok(await _healthUserService.GetAllHealthUsers());
        }

        // GET: api/HealthUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HealthUser>> GetHealthUser(int id)
        {
            var healthUser = await _healthUserService.GetHealthUserById(id);

            if (healthUser == null)
            {
                return NotFound();
            }

            return healthUser;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody]LoginDTO loginDTO)
        {
            var user = _healthUserService.Login(loginDTO);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                user.Result.Id,
                user.Result.Email,
                Token = tokenString
            });
        }


        // POST: api/HealthUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<HealthUser>> RegisterHealthUser(HealthUserDTO healthUserDTO)
        {

            var password = healthUserDTO.Password;
            healthUserDTO.Password = null;
            // map dto to entity
            var healthUser = _mapper.Map<HealthUser>(healthUserDTO);

            try
            {
                // save 
                var registeredUser = await _healthUserService.RegisterHealthUser(healthUser, password);
                return Ok(new { registeredUser.Id, registeredUser.Email, registeredUser.Name });
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }


        }

        // DELETE: api/HealthUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HealthUser>> DeleteHealthUser(int id)
        {
            var removedUser = await _healthUserService.DeleteHealthUser(id);

            if (removedUser == null)
            {
                return NotFound();
            }
               
            return removedUser;
        }

      /*  private bool HealthUserExists(int id)
        {
            return _context.HealthUsers.Any(e => e.Id == id);
        }

        // PUT: api/HealthUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHealthUser(int id, HealthUser healthUser)
        {
            if (id != healthUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(healthUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        } */
    }
}
