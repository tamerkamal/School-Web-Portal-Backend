using SchoolPortalAPI.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.DAL.Repositories
{
    public interface IMembersRepo
    {
        Task<Member> PostMember(Member member);
        IQueryable<Member> GetMembers();
    }
}
