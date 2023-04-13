using GhiasAmooz.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GhiasAmooz.DataLayer.Entities.Course;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Schema;

namespace GhiasAmooz.Web.Pages.Admin.Course
{
    public class EditCourseModel : PageModel
    {
        private ICourseService _courseService;

        public EditCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [BindProperty]
        public GhiasAmooz.DataLayer.Entities.Course.Course Course { get; set; }
        public void OnGet(int id)
        {
            Course = _courseService.GetCourseById(id);
            var groups =  _courseService.GetGroupForManageCourse();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");
            var subGroups =  _courseService.GetSubGroupForManageCourse(int.Parse(groups.First().Value));
            ViewData["SubGroups"] = new SelectList(subGroups, "Value", "Text");
            var teachers = _courseService.GetTeachers();
            ViewData["Teachers"] = new SelectList(teachers, "Value", "Text");

            var levels = _courseService.GetLevels();
            ViewData["Levels"] = new SelectList(levels, "Value", "Text");

            var status = _courseService.GetStatus();
            ViewData["Status"] = new SelectList(status, "Value", "Text");
        }
        public IActionResult OnPost(IFormFile imgCourseUp, IFormFile demoUp)
        {
            _courseService.UpdateCourse(Course, imgCourseUp, demoUp);
            return RedirectToPage("index");
        }
    }
}
