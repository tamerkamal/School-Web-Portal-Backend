using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BOL.Security
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
