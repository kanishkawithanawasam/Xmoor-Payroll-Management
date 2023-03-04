using Xmoor.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Xmoor.Main.Areas.Manager.Controllers
{
    public class GenEmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GenEmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var empList = _db.Linker.Join(_db.StaffPersonalDetails, 
            //                                user => user.staffId, 
            //                                persnRec=>persnRec.Id, 
            //                                (user,persnRec)=> new {user,persnRec} 
            //                        ).Join(
            //                            _db.Employments,
            //                            cmbRec=>cmbRec.user.,
            //                            employment=>employment.PayrollId,
            //                            (cmbRec,employment)=>new {cmbRec,employment}
            //                        ).Where(fullentry=>fullentry.employments.)
            return View();
        }
    }
}
