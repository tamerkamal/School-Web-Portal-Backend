using Microsoft.EntityFrameworkCore;
using SchoolPortalAPI.BOL;
using SchoolPortalAPI.Models;
using SchoolPortalAPI.ViewModels;
using System;
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
        public async Task<Member> PostMember(RegisterVModel registerVModel)
        {
            Guid membershipTypeId = _context.MembershipTypes.Where(m => m.Name == registerVModel.MembershipTypeName)
                                                            .Select(m => m.MembershipTypeId)
                                                            .Single();
            Member member = new Member()
            {
                Address = registerVModel.Address,
                BirthDate = registerVModel.BirthDate,
                Email = registerVModel.Email,
                FirstName = registerVModel.FirsName,
                LastName = registerVModel.LastName,
                Phone = registerVModel.Phone,
                MemberId = Guid.NewGuid(),
                MembershipTypeId = membershipTypeId
            };
            _dbset.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public IQueryable<Member> GetMembers()
        {
            return _dbset.Include(m => m.MembershipType);
        }
    }
}
