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
        CourseGroup GetById(int groupId);
        void AddGroup(CourseGroup group);
        void UpdateGroup(CourseGroup group);
        #endregion

        #region Course
        List<ShowCourseForAdminViewModel> GetCoursesForAdmin();   
        Tuple<List<ShowCourseListViewModel>, int> GetCourse(int pageId = 1, string filter = "", string getType = "all",
            string orderByType = "date", int startPrice = 0, int endPrice = 0, List<int> selectedGroups = null, int take = 0);
        int AddCourse(Course course, IFormFile imgCourse, IFormFile courseDemo);
        Course GetCourseById(int courseId);
        Course GetCourseForShow(int courseId);
        void UpdateCourse(Course course, IFormFile imgCourse, IFormFile courseDemo);
        List<ShowCourseListViewModel> GetPopularCourse();
        bool IsFree(int courseId);
        #endregion

        #region Episode
        int AddEpisode(CourseEpisode episode, IFormFile episodeFile);
        List<CourseEpisode> GetListEpisodeCorse(int courseId);
        bool CheckExistFile(string fileName);
        
        CourseEpisode GetEpisodeById(int episodeId);
        void EditEpisode(CourseEpisode episode, IFormFile episodeFile);
        #endregion

        #region Comments

        void AddComment(CourseComment comment);
        Tuple<List<CourseComment>, int> GetCourseComment(int courseId, int pageId = 1);

        #endregion

        #region CourseVote
        void AddVote(int userId, int courseId, bool vote);
        Tuple<int, int> GetCourseVote(int courseId);
        #endregion
    }
}
