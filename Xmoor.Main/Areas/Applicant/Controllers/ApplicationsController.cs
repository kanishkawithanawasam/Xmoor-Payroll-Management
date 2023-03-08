using Microsoft.AspNetCore.Mvc;
using Xmoor.DataAccess;
using Xmoor.Main.Areas.Applicant.ViewModels;
using Xmoor.Models;

namespace Xmoor.Main.Areas.Applicant.Controllers
{
    [Area("Applicant")]
    public class ApplicationsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<RoleOpennings> roleOpenigs =  _db.RoleOpennings.ToList();
            return View(roleOpenigs);
        }

        [HttpPost]
        public IActionResult  Index(string search)
        {
            IEnumerable<RoleOpennings> roleOpenigs = _db.RoleOpennings.Where(o=>o.Title.Contains(search) || o.KeyWords.Contains(search));
            return View(roleOpenigs);
        }


        [HttpGet]
        public IActionResult ViewApplication(int Id)
        {
            ViewApplicationVM applicationVM = new ViewApplicationVM();
            var roleOpenning = (from roleOpenings in _db.RoleOpennings
                               join departments in _db.Department on roleOpenings.DepartmentId equals departments.Id
                               join role in _db.Roles on roleOpenings.RoleId equals role.RoleId
                               select new
                               {
                                   TIT=roleOpenings.Title,
                                   CD=roleOpenings.CloseDate,
                                   DES=roleOpenings.Description,
                                   WH=roleOpenings.WorkingHours,
                                   RN=role.RoleName,
                                   DN=departments.Name
                               }).FirstOrDefault();

            applicationVM.Id = Id;
            applicationVM.Title = roleOpenning.TIT;
            applicationVM.RoleName = roleOpenning.RN;
            applicationVM.Description = roleOpenning.DES;
            applicationVM.DepartmentName = roleOpenning.DN;
            applicationVM.WorkingHours = roleOpenning.WH;
            applicationVM.CloseDate = roleOpenning.CD;
            return View(applicationVM);
        }

    }
}
