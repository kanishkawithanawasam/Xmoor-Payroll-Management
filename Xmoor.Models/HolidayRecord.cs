using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmoor.Models
{
    public class HolidayRecord
    {
        public int Id { get; set; }
        public DateTime HolidayStart { get; set; }
        public DateTime HolidayEnd { get; set;}
        public int HolidayType { get; set; }
        [ForeignKey(nameof(HolidayType))]
        public Holidays Holidays { get; set; }

        public int EmploymentId { get; set; }
        [ForeignKey(nameof(EmploymentId))]
        public Employment Employment { get; set; }
    }
}
