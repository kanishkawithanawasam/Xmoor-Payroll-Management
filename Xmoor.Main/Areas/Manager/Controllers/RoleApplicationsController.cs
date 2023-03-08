using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using Xmoor.DataAccess;
using Xmoor.Main.Areas.Manager.ViewModels;
using Xmoor.Models;
using Xmoor.Utility;

namespace Xmoor.Main.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class RoleApplicationsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RoleApplicationsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles =StaticDetails.Role_Manager)]
        public IActionResult NewApplication()
        {
            NewRoleVM roleVMObj = new NewRoleVM();
            roleVMObj.RoleList = _db.Roles.Select(
                    i => new SelectListItem
                    {
                        Text = i.RoleName,
                        Value = i.RoleId.ToString()
                    }
                ).ToList();
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
        [ValidateAntiForgeryToken]
        [Authorize(Roles = StaticDetails.Role_Manager)]
        public IActionResult NewApplication(NewRoleVM roleVMObj)
        {
            if (_signInManager.IsSignedIn(User))
            {
                roleVMObj.RoleOpenning.EditorId = (int)_db.RegistrationLog.FirstOrDefault(o => o.ApplicationUserId == (string)_userManager.GetUserId(User)).StaffDetailsId;
                roleVMObj.RoleOpenning.Published = true;
                if (!ModelState.IsValid)
                {
                    roleVMObj.RoleList = _db.Roles.Select(
                   i => new SelectListItem
                   {
                       Text = i.RoleName,
                       Value = i.RoleId.ToString()
                   }
               ).ToList();
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
                _db.RoleOpennings.Add(roleVMObj.RoleOpenning);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = StaticDetails.Role_Manager)]
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

