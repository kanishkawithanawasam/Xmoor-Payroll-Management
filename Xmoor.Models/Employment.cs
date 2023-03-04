using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmoor.Models
{
    public class Employment
    {
        [Key]
        public int PayrollId { get; set; }

        //The department may change 
        public int departmentTableId { get; set; }
        [ForeignKey(nameof(departmentTableId))]
        public Department Department { get; set; }


        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Roles Roles { get; set; }

        public string? PayrollIdChange { get; set; }
        public string? OldPayrollId { get; set; } //Old payroll Id for this employment
        public string? IrregularPayment { get; set; }  //Only put ‘Yes’ if the employee is not being paid regularly (for example, they’re a casual employee or on long-term sick leave) or if you’re not going to pay them for 3 months or more
        public bool ActiveEmployement { get; set; } = true;

        public string  userAccountId { get; set; }
        [ForeignKey("userAccountId")]
        public ApplicationUser applicationUser { get; set; }

        public int? staffId { get; set; }
        [ForeignKey(nameof(staffId))]
        public StaffPersonalDetails staffPersonalDetails { get; set; }
    }
}
