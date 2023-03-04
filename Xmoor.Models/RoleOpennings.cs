using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmoor.Models
{
    public class RoleOpennings
    {
        public int Id { get; set; }
        [Required]
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Roles Roles { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

        public DateTime OpeningDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime CloseDate { get; set; }

        [Required]
        public int description { get; set; }
    }
}
