using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BOL
{
    public class Member : IMember
    {
        [Key]
        public Guid MemberId { get; set; }
        public string FirsName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [ForeignKey("MembershipType")]
        public Guid MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}
