using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Xmoor.DataAccess;
using Xmoor.Main.Areas.GeneralStaff.ViewModels;
using Xmoor.Models;

namespace Xmoor.Main.Areas.Applicant.Controllers
{
    [Area("APPLICANT")]
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
        public IActionResult RegisterPeronalDetails()
        {
            var user = _db.ApplicationUser.Find(_userManager.GetUserAsync(HttpContext.User).Result.Id);
            if (user == null)
            {
                return BadRequest();
            }


            return View();
        }


    }
}
