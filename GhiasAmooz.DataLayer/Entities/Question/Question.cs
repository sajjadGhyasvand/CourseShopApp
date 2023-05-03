using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhiasAmooz.DataLayer.Entities.Question
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required(ErrorMessage ="عنوان سوال را وارد کنید.")]
        [Display(Name ="عنوان سوال")]
        [MaxLength(400)]
        public string Title { get; set; }
        [Required(ErrorMessage = "متن سوال را وارد کنید.")]
        [Display(Name = "متن سوال")]

        public string Body { get; set; }
        [Required]

        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        #region Relations
        public Course.Course Course { get; set; }
        public User.User User { get; set; }
        public List<Answer> Asnwers { get; set; }
        #endregion

    }
}
