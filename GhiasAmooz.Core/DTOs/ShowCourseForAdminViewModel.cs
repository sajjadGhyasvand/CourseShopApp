using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhiasAmooz.Core.DTOs
{
    public class ShowCourseForAdminViewModel
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string ImageName { get; set; }
        public int EpisodeCount { get; set; }
    }
}
