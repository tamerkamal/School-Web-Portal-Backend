using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolPortalAPI.BOL;
using SchoolPortalAPI.DAL;
using SchoolPortalAPI.ViewModels;

namespace SchoolPortalAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppSettingsVModel _appSettings;
        public UsersController(
           UserManager<AppUser> userManager,
           IOptions<AppSettingsVModel> appSettings)
        {
            _userManager = userManager;
            //_singInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<Object> Register(LoginVModel loginVModel)
        {
            var user = new AppUser()
            {
                UserName = loginVModel.UserName,
                Email = loginVModel.UserName
            };
            try
            {
                IdentityResult identityResult = await _userManager.CreateAsync(user, loginVModel.Password);

                return Ok(identityResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVModel model)
        {
            AppUser user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)),
                            SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }
    }
}