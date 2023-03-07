using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Role Name")]
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        [ValidateNever]
        public Roles Roles { get; set; }

        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [ValidateNever]
        public Department Department { get; set; }

        public int EditorId { get; set; }
        [ForeignKey(nameof (EditorId))]
        [ValidateNever]
        public StaffPersonalDetails staffPersonalDetails { get; set; }


        [DisplayName("Opening Date")]
        public DateOnly? OpeningDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        [DisplayName("Closing Date")]
        public DateOnly? CloseDate { get; set; }

        public bool Published { get; set; } = false;

        public bool IsClosed { get; set; } = false;

        [Required]
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
    }
}
