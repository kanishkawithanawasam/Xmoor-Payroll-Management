using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmoor.Models
{
    public class RegistrationLog
    {
        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser applicationUser { get; set; }

        public int? EmploymentId { get; set; }
        [ForeignKey(nameof(EmploymentId))]
        public Employment Employment { get; set; }

        public int? StaffDetailsId { get; set; }
        [ForeignKey(nameof(StaffDetailsId))]
        public StaffPersonalDetails StaffPersonalDetails { get; set; }

        public bool SalaryDetails_Confirmed = false;
        public DateTime? SalaryDetails_ConfirmedDate { get; set; }

        public bool EmploymentAgreement_Signed { get; set; } = false;
        public DateTime? EmploymentAgreement_SignedTime { get; set; }

        public bool Registration_Completed { get; set; } = false;
    }
}
