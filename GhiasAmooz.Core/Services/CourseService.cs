using GhiasAmooz.Core.Convertors;
using GhiasAmooz.Core.DTOs;
using GhiasAmooz.Core.Generator;
using GhiasAmooz.Core.Security;
using GhiasAmooz.Core.Services.Interfaces;
using GhiasAmooz.DataLayer.Context;
using GhiasAmooz.DataLayer.Entities.Course;
using GhiasAmooz.DataLayer.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhiasAmooz.Core.Services
{
    public class CourseService : ICourseService
    {
        private GhiasAmoozContext _context;

        public CourseService(GhiasAmoozContext context)
        {
            _context = context;
        }

        public int AddCourse(Course course, IFormFile imgCourse, IFormFile courseDemo)
        {
            course.CreateDate= DateTime.Now;
            course.CourseImageName = "default.jpg";
            //TODO: Check Image
            if (imgCourse!=null && imgCourse.IsImage())
            {
                course.CourseImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgCourse.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Course/Image", course.CourseImageName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgCourse.CopyTo(stream);
                }
                //Image Resize
                ImageConvertor ImageResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Course/thumb", course.CourseImageName);
                ImageResizer.Image_resize(imagePath, thumbPath,150);
            }
            //TODO: Upload Demo
            if (courseDemo != null)
            {
                course.DemoFileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(courseDemo.FileName);
                string demoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Course/Demo", course.DemoFileName);
                using (var stream = new FileStream(demoPath, FileMode.Create))
                {
                    courseDemo.CopyTo(stream);
                }
            }
            _context.Courses.Add(course);
            _context.SaveChanges();

            return course.CourseId;
        }

        public List<CourseGroup> GetAllGroup()
        {
            return _context.CourseGroups.ToList();
        }

        public List<ShowCourseForAdminViewModel> GetCoursesForAdmin()
        {
            return _context.Courses.Select(c => new ShowCourseForAdminViewModel()
            {
                CourseId= c.CourseId,
                ImageName=c.CourseImageName,
                CourseTitle=c.CourseTitle,
                EpisodeCount=c.CourseEpisodes.Count,
            }).ToList();

        } 

        public List<SelectListItem> GetGroupForManageCourse()
        {
            return _context.CourseGroups.Where(g => g.ParentId == null).Select(g => new SelectListItem()
            {
                Text = g.GroupTitle,
                Value = g.GroupId.ToString()
            }).ToList();
        }

        public List<SelectListItem> GetLevels()
        {
            return _context.CourseLevels.Select(l => new SelectListItem()
            {
                Value = l.LevelId.ToString(),
                Text = l.LevelTitle
            }).ToList();
        }

        public List<SelectListItem> GetStatus()
        {
            return _context.CourseStatuses.Select(s => new SelectListItem()
            {
                Value = s.StatusId.ToString(),
                Text = s.StatusTitle
            }).ToList();
        }

        public List<SelectListItem> GetSubGroupForManageCourse(int groupId)
        {
            return _context.CourseGroups.Where(g => g.ParentId == groupId).Select(g => new SelectListItem()
            {
                Text = g.GroupTitle,
                Value = g.GroupId.ToString()
            }).ToList();
        }

        public List<SelectListItem> GetTeachers()
        {
           return _context.UserRoles.Where(r=>r.RoleId == 2 ).Include(r=>r.User)
                .Select(u=> new SelectListItem()
                {
                    Value=u.UserId.ToString(),
                    Text=u.User.UserName
                }).ToList();
        }
    }
}
