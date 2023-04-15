using GhiasAmooz.Core.Services.Interfaces;
using GhiasAmooz.DataLayer.Entities.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GhiasAmooz.Web.Pages.Admin.Course
{
    public class CreateEpisodeModel : PageModel
    {
        private ICourseService _courseService;

        public CreateEpisodeModel(ICourseService courseService)
        {
            _courseService = courseService;
        }



        [BindProperty]
        public CourseEpisode CourseEpisode { get; set; }
        public void OnGet(int id)
        {
            CourseEpisode = new CourseEpisode();
            CourseEpisode.CourseId = id;

        }


       public IActionResult OnPost(IFormFile fileEpisode)
        {
            

            if (_courseService.CheckExistFile(fileEpisode.FileName))
            {
                ViewData["IsExistFile"] = true;
                return Page();
            }


            _courseService.AddEpisode(CourseEpisode, fileEpisode);

            return Redirect("/Admin/Course/IndexEpisode/" + CourseEpisode.CourseId);
        }
    }

}
