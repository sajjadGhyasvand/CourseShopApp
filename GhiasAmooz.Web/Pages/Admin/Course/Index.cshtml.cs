using GhiasAmooz.Core.DTOs;
using GhiasAmooz.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GhiasAmooz.Web.Pages.Admin.Course
{
    public class IndexModel : PageModel
    {
        private ICourseService _courseService;

        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public List<ShowCourseForAdminViewModel> ListCourse { get; set; }
        public void OnGet()
        {
            ListCourse = _courseService.GetCoursesForAdmin();
        }
    }
}
