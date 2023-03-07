using Microsoft.AspNetCore.Mvc;

namespace Xmoor.Main.Areas.Manager.Controllers
{
    public class EmploymentController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult NewEmployment()
        {
            return View();
        }

    }
}
