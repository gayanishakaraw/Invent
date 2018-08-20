using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Invent.Web.Business.Repositories;
using Invent.Web.Common.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Globalization;
using System.Linq;

namespace Invent.Web.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUsersBsRepository _userBsRepository;
        private readonly IConfiguration _configuration;

        public UsersController(IUsersBsRepository userBsRepository, IConfiguration configuration)
        {
            _userBsRepository = userBsRepository;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(string email, string password)
        {
            var user = await _userBsRepository.AuthenticateAsync(email, password);

            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Authentication:Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString(CultureInfo.CurrentCulture)),
                    new Claim(ClaimTypes.Role, user.RoleId.ToString(CultureInfo.CurrentCulture))
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                user.FirstName,
                user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(Users userDto)
        {
            try
            {
                await _userBsRepository.CreateAsync(userDto, userDto.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var users = await _userBsRepository.GetAllAsync().ConfigureAwait(false);
                if (users != null)
                {
                    var userList = from user in users
                                   select new
                                   {
                                       user.UserId,
                                       user.UserName,
                                       user.Email,
                                       user.FirstName,
                                       user.LastName,
                                       user.RoleId,
                                       user.IsActive,
                                       user.CompanyId
                                   };

                    return Ok(userList);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var user = await _userBsRepository.GetByIdAsync(id);

                if (user != null)
                    return Ok(new
                    {
                        user.UserId,
                        user.UserName,
                        user.Email,
                        user.FirstName,
                        user.LastName,
                        user.RoleId,
                        user.IsActive,
                        user.CompanyId
                    });
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Users userDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userBsRepository.UpdateAsync(userDto, userDto.Password, true);
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _userBsRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}