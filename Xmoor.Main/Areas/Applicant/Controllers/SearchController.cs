using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xmoor.DataAccess;

namespace Xmoor.Main.Areas.Applicant.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SearchController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string searchString = HttpContext.Request.Query["searchString"].ToString();
                var searchResult =  _db.RoleOpennings.Where(o=>o.Description.Contains(searchString)).ToList();
                return Ok(searchResult);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
