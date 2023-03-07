using Microsoft.AspNetCore.Mvc;

namespace Xmoor.Main.Areas.Applicant.Controllers
{
    [Area("Applicant")]
    public class ApplicationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult  Search()
        {
            return View();
        }
    }
}
