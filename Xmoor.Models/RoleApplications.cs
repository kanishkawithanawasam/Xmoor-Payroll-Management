using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmoor.Models
{
    public class RoleApplications
    {
        public int Id { get; set; }

        public int RoleOpeningId { get; set; }
        [ForeignKey(nameof(RoleOpeningId))]

        [Required]
        public string cv { get; set; }

        [Required]
        public string coverLetter { get; set; }


        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
}
