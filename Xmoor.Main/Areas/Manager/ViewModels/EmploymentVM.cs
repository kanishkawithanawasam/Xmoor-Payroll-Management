using Xmoor.Models;

namespace Xmoor.Main.Areas.Manager.ViewModels
{
    public class EmploymentVM
    {
        public IEnumerable<Employment> Employment { get; set; }

        public IEnumerable<RoleApplications> RoleApplications { get; set; }

    }
}
