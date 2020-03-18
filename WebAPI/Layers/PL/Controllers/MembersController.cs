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
using SchoolPortalAPI.DAL.Repositories;
using SchoolPortalAPI.Models;
using SchoolPortalAPI.ViewModels;

namespace SchoolPortalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersRepo _repo;
        public MembersController(IMembersRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<Member> RegisterMember(Member member)
        {
            return await _repo.RegisterMember(member);
        }
    }
}