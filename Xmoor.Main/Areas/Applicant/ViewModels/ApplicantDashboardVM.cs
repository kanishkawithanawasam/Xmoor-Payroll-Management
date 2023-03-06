using System.ComponentModel.DataAnnotations.Schema;
using Xmoor.Models;

namespace Xmoor.Main.Areas.Applicant.ViewModels
{
    public class ApplicationSubmits
    {
        public int Id { get; set; }

        public string Role { get; set; }

        public string Status { get; set; }

        public DateOnly LastUpdate { get; set; }
    }


    public class ApplicantDashboardVM
    {
        public bool RegistrationOpen { get; set; } = false;

        public bool? SalaryDetails_Confirmed { get; set; }
        public DateTime? SalaryDetails_ConfirmedDate { get; set; }

        public bool? EmploymentAgreement_Signed { get; set; }
        public DateTime? EmploymentAgreement_SignedTime { get; set; }

        public bool? Registration_Completed { get; set; }

        public IEnumerable<ApplicationSubmits>? applications { get; set; }
    }
}
