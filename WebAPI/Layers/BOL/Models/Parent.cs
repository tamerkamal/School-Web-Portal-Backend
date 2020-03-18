using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BOL
{
    public class Parent : Member
    {
        public string Profession { get; set; }
        public string EduQualification { get; set; }
    }
}
