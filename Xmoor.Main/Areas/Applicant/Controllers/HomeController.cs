using Microsoft.AspNetCore.Mvc;

namespace Xmoor.Main.Areas.Applicant.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
