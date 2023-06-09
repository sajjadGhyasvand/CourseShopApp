﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using GhiasAmooz.DataLayer.Entities.Order;

namespace GhiasAmooz.DataLayer.Entities.Course
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        
       

        public int? SubGroup { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public int LevelId { get; set; }

        [Display(Name = "عنوان دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CourseTitle { get; set; }

        [Display(Name = "شرح دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseDescription { get; set; }

        [Display(Name = "قیمت دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CoursePrice { get; set; }

        [MaxLength(600)]
        public string Tags { get; set; }

        [MaxLength(50)]
        public string CourseImageName { get; set; }

        [MaxLength(100)]
        public string DemoFileName { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        #region Relations

        [ForeignKey("TeacherId")]
        public User.User User { get; set; }

        
        public  CourseGroup CourseGroup { get; set; }
        public int CourseGroupId { get; set; }



        [ForeignKey("SubGroup")]
        public virtual CourseGroup Group { get; set; }

        public CourseStatus Status { get; set; }

        public CourseLevel Level { get; set; }

        public List<CourseEpisode> CourseEpisodes { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<UserCourse> UserCourses { get; set; }
        public List<CourseComment> CourseComments { get; set; }
        public List<CourseVote> CourseVotes { get; set; }
        public List<Question.Question> Questions { get; set; }

        #endregion
    }
}
