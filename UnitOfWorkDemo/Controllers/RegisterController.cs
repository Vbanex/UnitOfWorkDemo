using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UnitOfWorkDemo.Account;
using UnitOfWorkDemo.Core.Models;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWorkDemo.Controllers
{

    [Route("api/account/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IUserStore<ApplicationUser> _userStore;

        public RegisterController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
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
         
            if(result.Succeeded){
            _logger.LogInformation("A new user was created");
            return Ok(result);
            }

            return StatusCode(StatusCodes.Status400BadRequest, result.Errors);
            
          
        }
    }
}
