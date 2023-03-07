using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Xmoor.DataAccess;
using Xmoor.Main.Areas.Applicant.ViewModels;
using Xmoor.Models;
using Xmoor.Utility;

namespace Xmoor.Main.Areas.Applicant.Controllers
{
    // This will manage user rehistration after a successful application.
    public class RegisterController : Controller
    { 
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// The HomeController shows a to-do list for new employees.
        /// The HomeController displays details such as remaining holidays, used holidays, shift history.
        /// </summary>
        public RegisterController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _userManager = userManager;
            _db = db;
            _signInManager = signInManager;
        }


        [Authorize(Roles = StaticDetails.Role_Applicant + "," + StaticDetails.Role_General_Staff + "," + StaticDetails.Role_Manager)]
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = _userManager.GetUserAsync(User).Result;
                ApplicantDashboardVM dashObj = new ApplicantDashboardVM();
                if (user == null)
                {
                    TempData["User Error"] = "User could not be found!";
                    return Redirect("Identity/Account/Login");
                }

                var registrationLog = _db.RegistrationLog.FirstOrDefault(r => r.ApplicationUserId == user.Id);
                if (registrationLog == null)
                {
                    dashObj.RegistrationOpen = false;
                }
                return View(dashObj);
            }
            else
            {
                return Redirect("Identity/Account/Login");

            }

        }


        [HttpGet]
        [Authorize(Roles = StaticDetails.Role_Applicant + "," + StaticDetails.Role_General_Staff + "," + StaticDetails.Role_Manager)]
        public IActionResult RegisterPersonalDetails()
        {
            if (_signInManager.IsSignedIn(User))
            {
                #pragma warning disable CS8602 // User sign in is already validated. 
                var user = _db.ApplicationUser.Find(_userManager.GetUserAsync(HttpContext.User).Result.Id);
                RegisterVM registerObj = new RegisterVM();
                registerObj.StaffPersonalDetails.Email = user.Email;
                return View(registerObj);
                #pragma warning restore CS8602

            }
            else
            {
                return Redirect("Identity/Account/Login");
            }


        }


        [HttpPost]
        [Authorize(Roles = StaticDetails.Role_Applicant + "," + StaticDetails.Role_General_Staff + "," + StaticDetails.Role_Manager)]
        public IActionResult RegisterPersonalDetails(RegisterVM registerObj)
        {
            if (!ModelState.IsValid)
            {

                return View(registerObj);
            }
            _db.StaffPersonalDetails.Add(registerObj.StaffPersonalDetails);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
