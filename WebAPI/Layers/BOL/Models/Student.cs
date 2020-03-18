using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BOL
{
    public class Student : Member
    {
        [Required]
        [ForeignKey("Stage")]
        public Guid StageId { get; set; }
        public Stage Stage { get; set; }
    }
}
