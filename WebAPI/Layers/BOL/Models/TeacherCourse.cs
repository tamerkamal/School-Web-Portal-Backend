using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BOL
{
    public class TeacherCourse
    {
        [Key]
        public Guid TeacherCourseId { get; set; }
        [ForeignKey("Teacher")]
        public Guid MemberId { get; set; }
        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        public Teacher MyProperty { get; set; }
        public Course Course { get; set; }
    }
}
