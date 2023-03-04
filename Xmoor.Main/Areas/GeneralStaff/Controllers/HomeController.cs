using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Xmoor.DataAccess;
using Xmoor.Main.Areas.GeneralStaff.ViewModels;
using Xmoor.Models;
using Xmoor.Utility;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Xmoor.Main.Areas.GeneralStaff.Controllers
{
    [Area("GeneralStaff")]
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
        public  HomeController( UserManager<ApplicationUser> userManager,ApplicationDbContext db)
        {
            _userManager = userManager;
            _db= db;
        }

        /// <summary>
        /// The index page contain basic data about the current user. A view model is used to pass data from the controller to the view.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            GeneralStaffDashboardVM dashboard = new GeneralStaffDashboardVM();


            int _employmentId;
            List<ShiftRecord> totalShifts;
            double totalHousrs = 0;
        

            DateTime firstOfMonth = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);


            //The following code takes the EmployementID  of the current user for the current employment
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            _employmentId =_db.ApplicationUser.Join(
                _db.Employments, user => user.Id, employment => employment.userAccountId, 
                (user, employment) => new{ ApplicationUser = user, Employment = employment}).FirstOrDefault(user=> user.ApplicationUser.Id == _userManager.GetUserId(HttpContext.User)).Employment.PayrollId;
            #pragma warning restore CS8602 // Dereference of a possibly null reference.


            
            dashboard.shiftRecords = _db.ShiftRecords.OrderBy(x => x.SheduledEnd).Take(7).Where(x=>x.EmploymentId == _employmentId).ToList();

            
            totalShifts = _db.ShiftRecords.Where(x =>x.Start > firstOfMonth).ToList();
            foreach(var i in totalShifts)
            {
                if(i.Start != null && i.End != null)
                {
                    totalHousrs += (double)((DateTime)i.Start - (DateTime)i.End).TotalHours;
                }
            }
            dashboard.TotalHours = totalHousrs;
            dashboard.LastHolidays = _db.HolidayRecords.OrderByDescending(h => h.HolidayStart).Take(5).ToList();

            return View(dashboard);
        }
    }
}
