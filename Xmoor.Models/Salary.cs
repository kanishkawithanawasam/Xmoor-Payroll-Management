using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmoor.Models
{
    //The following model contains the contracted employment related details details.
    public class Salary
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double HourlyPay { get; set; }
        [Required]
        public double OvertimePay { get; set; }
        [Required]
        public DateTime ShiftStart { get; set; }
        [Required]
        public DateTime ShiftEnd { get; set; }
        [Required]
        public double WeeklyHours { get; set; }
        [Required]
        public double AnnualHolidays { get; set; }
        public double AnnualHolidayPayRate { get;set; }
        public double SickPayRate { get; set; }
        public int NumPaidSickHoliday { get; set; } = 0;

        public int PayrollId { get; set; }
        [ForeignKey(nameof(PayrollId))]
        public Employment Employment { get; set; }


    }
}
