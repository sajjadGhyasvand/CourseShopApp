using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhiasAmooz.DataLayer.Entities.Question
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        [Required]
        public int UserId { get; set; }
        public User.User user { get; set; }
        [Required]
        public string BodyAnswer { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsTrue { get; set; } = false;
    }
}
