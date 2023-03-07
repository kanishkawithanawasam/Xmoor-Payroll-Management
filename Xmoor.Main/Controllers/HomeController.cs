using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Xmoor.Models;

namespace Xmoor.Main.Controllers
{
    public class HomeController : Controller
    {
        public SignInManager<ApplicationUser> _signInManager { get; set; }

        public HomeController(SignInManager<ApplicationUser> signInManager) {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return Redirect("Applicant/Applications/Index");
            }
            else
            {
                return Redirect("Identity/Account/Login");
            }
        }
    }
}
