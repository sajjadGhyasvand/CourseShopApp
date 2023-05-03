using GhiasAmooz.DataLayer.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace GhiasAmooz.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseAPiController : ControllerBase
    {
        private GhiasAmoozContext _context;

        public CourseAPiController(GhiasAmoozContext context)
        {
            _context = context;
        }
        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var CourseTitle = _context.Courses.Where(c=>c.CourseTitle.Contains(term)).Select(c=>c.CourseTitle).ToList();
                return Ok(CourseTitle);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
