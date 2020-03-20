using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BOL
{
    public interface IMember
    {
        [Key]
        Guid MemberId { get; set; }
        [Required]
        string FirstName { get; set; }
        [Required]
        string LastName { get; set; }
        [Required]
        string Email { get; set; }
        [Required]
        string Phone { get; set; }
        [Required]
        string Address { get; set; }
        [Required]
        Guid MembershipTypeId { get; set; }
        MembershipType MembershipType { get; set; }
    }
}
