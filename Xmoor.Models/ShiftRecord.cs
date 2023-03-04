using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmoor.Models
{
    public class ShiftRecord
    {
        [Key]
        public int Id { get; set; }
        public DateTime SheduledStart { get; set; }
       
        public DateTime SheduledEnd { get;set; }
        
        public DateTime? Start { get; set; }
        
        public DateTime? End { get; set; }
        public double OTHours { get; set; } = 0;


        public int EmploymentId { get; set; }
        [ForeignKey(nameof(EmploymentId))]
        public Employment Employment { get; set; }
    }
}
