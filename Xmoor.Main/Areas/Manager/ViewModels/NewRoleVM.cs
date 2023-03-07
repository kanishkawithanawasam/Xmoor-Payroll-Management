using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Xmoor.Models;

namespace Xmoor.Main.Areas.Manager.ViewModels
{
    public class NewRoleVM
    { 
        public RoleOpennings RoleOpenning { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> DepartmentList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
