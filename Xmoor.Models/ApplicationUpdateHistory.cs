using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmoor.Utility;

namespace Xmoor.Models
{
    /// <summary>
    /// This class is used to store history of each application.
    /// </summary>
    public class ApplicationUpdateHistory
    {
        public int Id { get; set; }

        public int ApplicationId { get; set; }
        [ForeignKey(nameof(ApplicationId))]
        public RoleApplications applications { get; set; }

        public string ApplicationStatus { get; set; } = StaticDetails.ApplicationStatus_SUBMITTED;
 
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
