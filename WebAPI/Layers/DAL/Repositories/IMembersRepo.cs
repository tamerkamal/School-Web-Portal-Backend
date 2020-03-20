using SchoolPortalAPI.BOL;
using SchoolPortalAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.DAL.Repositories
{
    public interface IMembersRepo
    {
        Task<Member> PostMember(RegisterVModel member);
        IQueryable<Member> GetMembers();
    }
}
