using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BOL
{
    public class Teacher : Member
    {
        [Required]
        public string TeachingExperience { get; set; }
    }
}
