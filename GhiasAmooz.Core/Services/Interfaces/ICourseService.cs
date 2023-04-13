using GhiasAmooz.Core.DTOs;
using GhiasAmooz.DataLayer.Entities.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhiasAmooz.Core.Services.Interfaces
{
    public interface ICourseService
    {
        #region Group
        List<CourseGroup> GetAllGroup();
        List<SelectListItem> GetGroupForManageCourse();
        List<SelectListItem> GetSubGroupForManageCourse(int groupId);
        List<SelectListItem> GetTeachers();
        List<SelectListItem> GetLevels();
        List<SelectListItem> GetStatus();
        #endregion

        #region Course
        List<ShowCourseForAdminViewModel> GetCoursesForAdmin();

        int AddCourse(Course course, IFormFile imgCourse, IFormFile courseDeme);
        #endregion
    }
}
