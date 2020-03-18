using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BOL
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
