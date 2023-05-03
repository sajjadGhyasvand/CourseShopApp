using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GhiasAmooz.Core.Services.Interfaces;
using GhiasAmooz.DataLayer.Entities.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GhiasAmooz.Web.Pages.Admin.CourseGroups
{
    public class CreateGroupModel : PageModel
    {
        private ICourseService _courseService;

        public CreateGroupModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public CourseGroup CourseGroups { get; set; }

        public void OnGet(int? id)
        {
            CourseGroups=new CourseGroup()
            {
                ParentId = id
            };
        }

        public IActionResult OnPost()
        {
            _courseService.AddGroup(CourseGroups);
            return RedirectToPage("Index");
        }
    }
}