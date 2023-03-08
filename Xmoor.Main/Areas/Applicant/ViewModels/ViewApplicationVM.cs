using Xmoor.Models;

namespace Xmoor.Main.Areas.Applicant.ViewModels
{
    public class ViewApplicationVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DepartmentName { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateOnly? CloseDate { get; set; }
        public string WorkingHours { get; set; }
    }
}
