using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Xmoor.Utility;

namespace Xmoor.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string OtherNames { get; set; }
        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public int? staffId { get; set; }
        [ForeignKey(nameof(staffId))]
        public StaffPersonalDetails staffPersonalDetails { get; set; }

        public string RegStatus = "UNREQUESTED";

        public string UserStatus = StaticDetails.Role_Applicant;
    }
}