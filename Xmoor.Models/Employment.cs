using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmoor.Models
{
    /// <summary>
    /// This class conians majority of datails required by HMRC.
    /// Please note that each Employment is unique for each hiring process and EmploymentId is used as the Payroll ID
    /// </summary>
    public class Employment
    {
        [Key]
        public int EmploymentId { get; set; }

        public bool EmploymentIdChange { get; set; } = false;

        public string? IrregularPayment { get; set; }  //Only put ‘Yes’ if the employee is not being paid regularly (for example, they’re a casual employee or on long-term sick leave) or if you’re not going to pay them for 3 months or more

        public bool ActiveEmployement { get; set; } = false;

        public string UserAgreement { get;set; } // Link to the agreement pdf file;

        public int departmentTableId { get; set; }
        [ForeignKey(nameof(departmentTableId))]
        public Department Department { get; set; }

        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Roles Roles { get; set; }
    }
}
