using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UnitOfWorkDemo.Account;
using UnitOfWorkDemo.Core.Models;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace UnitOfWorkDemo.Controllers
{

    [Route("api/account/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private IConfiguration _config;

        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger, IConfiguration config)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Email = registerModel.Email,
                PhoneNumber = registerModel.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.FirstName
              };
           
            var result = await _userManager.CreateAsync(user, registerModel.Password);
         
            if(!result.Succeeded){
               return StatusCode(StatusCodes.Status400BadRequest, result.Errors);
               
            }
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            }


            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            _logger.LogInformation("A new user was created");
            return Ok(result);
//end of register method
        }

        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.UserName);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var token = GenerateToken(user, userRoles);
            return Ok(token);

         
        }


        private string GenerateToken(ApplicationUser user, IList<String> roles)
        {
            try
            {
               
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
                };

                foreach(var userRole in roles) {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
