using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Xmoor.DataAccess;
using Xmoor.Main.Areas.Manager.ViewModels;
using Xmoor.Models;

namespace Xmoor.Main.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles ="Manager")]
    public class RoleOpenningsController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RoleOpenningsController(ApplicationDbContext db,UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager= userManager;
            _signInManager  = signInManager;
            _db = db;
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
            RoleOpenningsDashboardVM dashObj = new RoleOpenningsDashboardVM();

            dashObj.RoleOpennings = _db.RoleOpennings.Where(r => r.IsClosed == false);

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult CreateNew()
        {
            NewRoleVM roleVMObj = new NewRoleVM();
            roleVMObj.RoleList = _db.Roles.Select(
                    i => new SelectListItem
                    {
                        Text = i.RoleName,
                        Value = i.RoleId.ToString()
                    }
                ).ToList() ;
            roleVMObj.DepartmentList = _db.Department.Select(
                    i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }
                ).ToList();
            roleVMObj.RoleOpenning = new RoleOpennings();
            return View(roleVMObj);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult CreateNew(NewRoleVM roleVMObj)
        {
            if (_signInManager.IsSignedIn(User))
            {
                roleVMObj.RoleOpenning.Published = true;
                if (!ModelState.IsValid)
                {
                    return View(roleVMObj);
                }
                _db.RoleOpennings.Add(roleVMObj.RoleOpenning);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public IActionResult SaveDraft(NewRoleVM roleVMObj)
        {
            if (_signInManager.IsSignedIn(User))
            {
                roleVMObj.RoleOpenning.Published = true;
                if (!ModelState.IsValid)
                {
                    return View("CreateNew", roleVMObj);
                }
                _db.RoleOpennings.Add(roleVMObj.RoleOpenning);
                _db.SaveChanges();
            } 
            return RedirectToAction("Index");
        }

    }
}
