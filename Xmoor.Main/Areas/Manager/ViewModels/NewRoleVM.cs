using Microsoft.AspNetCore.Mvc.Rendering;
using Xmoor.Models;

namespace Xmoor.Main.Areas.Manager.ViewModels
{
    public class NewRoleVM
    {
        public RoleOpennings RoleOpenning { get; set; }

        public List<SelectListItem> DepartmentList { get; set; }

        public List<SelectListItem> RoleList { get; set; }
    }
}
