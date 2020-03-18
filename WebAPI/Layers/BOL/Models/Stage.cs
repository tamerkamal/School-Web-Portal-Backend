using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BOL
{
    public class Stage
    {
        [Key]
        public Guid StageId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
