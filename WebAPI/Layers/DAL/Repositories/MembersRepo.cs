using Microsoft.EntityFrameworkCore;
using SchoolPortalAPI.BOL;
using SchoolPortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.DAL.Repositories
{
    public class MembersRepo : IMembersRepo
    {
        private readonly SchoolDbContext _context;
        private readonly DbSet<Member> _dbset;
        public MembersRepo(SchoolDbContext context)
        {
            _context = context;
            _dbset = _context.Set<Member>();
        }
        public async Task<Member> RegisterMember(Member memberObj)
        {
            Member member = new Member()
            {
                Address = memberObj.Address,
                BirthDate = memberObj.BirthDate,
                Email = memberObj.Email,
                FirsName = memberObj.FirsName,
                LastName = memberObj.LastName,
                Phone = memberObj.Phone,
                MemberId = Guid.NewGuid(),
                MembershipTypeId = memberObj.MembershipTypeId
            };
            _dbset.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }
    }
}
