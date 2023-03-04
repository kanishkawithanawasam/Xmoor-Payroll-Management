using Xmoor.Models;

namespace Xmoor.Main.Areas.GeneralStaff.ViewModels
{
    public class GeneralStaffDashboardVM
    {
        public List<ShiftRecord>? shiftRecords { get; set; }

        public double? TotalHours { get; set; }

        public double? RemainingHolidays { get; set;}

        public StaffPersonalDetails StaffPersonalDetails { get; set; }

        public List<HolidayRecord>? LastHolidays { get; set; }

        public string regStatus { get; set; } = "INPROGRESS";
    }
}
