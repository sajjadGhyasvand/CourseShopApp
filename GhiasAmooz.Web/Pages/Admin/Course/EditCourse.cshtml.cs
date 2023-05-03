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

            var groups = _courseService.GetGroupForManageCourse();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text", Course.CourseGroupId);

            List<SelectListItem> subgroups = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };
            subgroups.AddRange(_courseService.GetSubGroupForManageCourse(Course.CourseGroupId));
            string selectedSubGroup = null;
            if (Course.SubGroup != null)
            {
                selectedSubGroup = Course.SubGroup.ToString();
            }
            ViewData["SubGroups"] = new SelectList(subgroups, "Value", "Text", selectedSubGroup);

            var teachers = _courseService.GetTeachers();
            ViewData["Teachers"] = new SelectList(teachers, "Value", "Text", Course.TeacherId);

            var levels = _courseService.GetLevels();
            ViewData["Levels"] = new SelectList(levels, "Value", "Text", Course.LevelId);

            var statues = _courseService.GetStatus();
            ViewData["Status"] = new SelectList(statues, "Value", "Text", Course.StatusId);
        }
        public IActionResult OnPost(IFormFile imgCourseUp, IFormFile demoUp)
        {
            _courseService.UpdateCourse(Course, imgCourseUp, demoUp);
            return RedirectToPage("index");
        }
    }
}
