using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Management.Dtos;
using Blog_Management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Management.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager){

            _userManager = userManager;
        }

        [HttpPost("/registser")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {

            try {
                if(!ModelState.IsValid)
                return BadRequest(ModelState);

                var appUser = new AppUser
                {

                    UserName = register.Username,
                    Email = register.Email
                };
                var createUser = await _userManager.CreateAsync(appUser, register.Password);
                if(createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser,"User");
                }

            }catch (Exception e){

            }
            

        }
        
    }
}