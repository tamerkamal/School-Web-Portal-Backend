using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolPortalAPI.BLL;
using SchoolPortalAPI.BOL;
using SchoolPortalAPI.BOL.Security;
using SchoolPortalAPI.DAL.Repositories;
using SchoolPortalAPI.ViewModels;

namespace SchoolPortalAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [AllowAnonymous]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppSettingsVModel _appSettings;
        private readonly IMembersRepo _repo;
        private readonly IPaginationService<Member> _paginationService;
        public UsersController(
           UserManager<AppUser> userManager,
           IOptions<AppSettingsVModel> appSettings,
           IPaginationService<Member> paginationService,
           IMembersRepo repo)
        {
            _userManager = userManager;
            //_singInManager = signInManager;
            _appSettings = appSettings.Value;
            _repo = repo;
            _paginationService = paginationService;
        }

        [HttpPost]
        // Post: /Users/Register
        public async Task<Object> Register(RegisterVModel registerVModel)
        {
            try
            {
                var user = new AppUser()
                {
                    UserName = registerVModel.Email,
                    Email = registerVModel.Email
                };
                List<string> userRoles = new List<string>(new string[] { "Member" });
                List<string> memberRoleOptions = new List<string>(new string[] { "Student", "Teacher", "Parent" });
                if (memberRoleOptions.Contains(registerVModel.MembershipTypeName))
                {
                    userRoles.Add(registerVModel.MembershipTypeName);
                }
                IdentityResult identityResult = await _userManager.CreateAsync(user, registerVModel.Password);
                if (identityResult.Succeeded)
                {
                    await _userManager.AddToRolesAsync(user, userRoles);
                    await _repo.PostMember(registerVModel);
                }
                return Ok(identityResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        // Post: /Users/AdminLogin
        public async Task<IActionResult> AdminLogin(LoginVModel model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.UserName);
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Admin"))
            {
                throw new UnauthorizedAccessException();
            }
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
            else { return BadRequest(new { message = "Username or password is incorrect." }); }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        //Get:/Users/Get
        public IEnumerable<Member> Get()
        {
            return _repo.GetMembers().ToList();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{pageNum}/{pageSize}/{sortBy?}/{isSortDesc?}")]
        //Get:/Users/Get/{pageNum}/{pageSize?}/{sortBy?}/{isSortDesc?}
        public IEnumerable<Member> GetWithPagAndSort(int pageNum, int pageSize, string sortBy, bool isSortDesc = false)
        {
            if (sortBy == "null")
            {
                return _paginationService.GetPageRecords(Get(), pageSize, pageNum);
            }
            IEnumerable<Member> members = _repo.GetMembers().Sort(sortBy, isSortDesc);
            if (isSortDesc)
            {
                members = members.ToList().Reverse<Member>();
            }
            return _paginationService.GetPageRecords(members, pageSize, pageNum);
        }
    }
}