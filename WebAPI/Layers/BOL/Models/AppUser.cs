﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BOL
{
    public class AppUser : IdentityUser<string>
    {
        public string FullName { get; set; }
    }
}
