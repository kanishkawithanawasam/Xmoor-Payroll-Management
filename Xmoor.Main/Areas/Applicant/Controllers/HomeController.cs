using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Xmoor.DataAccess;
using Xmoor.Main.Areas.Applicant.ViewModels;
using Xmoor.Utility;
using Xmoor.Models;

namespace Xmoor.Main.Areas.Applicant.Controllers
{
    [Area("Applicant")]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// The HomeController shows a to-do list for new employees.
        /// The HomeController displays details such as remaining holidays, used holidays, shift history.
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="db"></param>
        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            var user = _db.ApplicationUser.Find(_userManager.GetUserAsync(HttpContext.User).Result.Id);

            if (user == null)
            {
                return BadRequest();
            }

            ApplicantDashboardVM dashObj = new ApplicantDashboardVM();
            dashObj.regStatus = user.RegStatus;
            dashObj.UserStatus = user.UserStatus;

            if (user.RegStatus == "UNREQUESTED")
            {
                return View(dashObj);
            }
            else
            {
                dashObj.StaffPersonalDetails = _db.StaffPersonalDetails.FirstOrDefault(O => O.Id == user.staffId);
                return View(dashObj);
            }
        }


        [HttpGet]
        [Authorize(Roles = StaticDetails.Role_Applicant)]
        public IActionResult RegisterPersonalDetails() {
            var user = _db.ApplicationUser.Find(_userManager.GetUserAsync(HttpContext.User).Result.Id);
            RegisterVM registerObj = new RegisterVM();
            registerObj.StaffPersonalDetails.Email = user.Email;
            return View(registerObj);
        
        }


        [HttpPost]
        [Authorize(Roles = StaticDetails.Role_Applicant)]
        public IActionResult RegisterPersonalDetails(RegisterVM registerObj)
        {
            if (!ModelState.IsValid)
            {
                return View(registerObj);
            }

            return RedirectToAction("Index");
        }

    }
}
