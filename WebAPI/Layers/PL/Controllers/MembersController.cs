using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolPortalAPI.BOL;
using SchoolPortalAPI.BLL;
using SchoolPortalAPI.DAL.Repositories;
using SchoolPortalAPI.Models;
using SchoolPortalAPI.ViewModels;

namespace SchoolPortalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IPaginationService<Member> _paginationService;
        private readonly IMembersRepo _repo;
        public MembersController(IMembersRepo repo, IPaginationService<Member> paginationService)
        {
            _repo = repo;
            _paginationService = paginationService;
        }

        [AllowAnonymous]
        [HttpPost]
        //Post :/Members/Post
        public async Task<Member> Post(Member member)
        {
            return await _repo.PostMember(member);
        }

        [Authorize]
        [HttpGet("{pageNum}/{pageSize}/{sortBy}/{isSortDesc}")]
        //Get:/Members/Get/{pageNum}/{pageSize}/{sortBy}/{isSortDesc}
        public List<Member> Get(int pageNum, int pageSize, string sortBy, bool isSortDesc = false)
        {
            IQueryable<Member> members = _repo.GetMembers().Sort(sortBy, isSortDesc);
            return _paginationService.GetPageRecords(members, pageSize, pageNum).ToList();
        }
    }
}