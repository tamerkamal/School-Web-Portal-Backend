using SchoolPortalAPI.BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BOL
{
    public class TeacherStage
    {
        [Key]
        public Guid TeacherStageId { get; set; }
        [ForeignKey("Teacher")]
        public Guid MemberId { get; set; }
        [ForeignKey("Stage")]
        public Guid StageId { get; set; }
        public Teacher Teacher { get; set; }
        public Stage Stage { get; set; }
    }
}
