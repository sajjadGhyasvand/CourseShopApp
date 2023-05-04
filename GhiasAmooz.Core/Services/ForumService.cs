using GhiasAmooz.Core.DTOs;
using GhiasAmooz.Core.Services.Interfaces;
using GhiasAmooz.DataLayer.Context;
using GhiasAmooz.DataLayer.Entities.Question;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GhiasAmooz.Core.Services
{
    public class ForumService : IForumService
    {
        private GhiasAmoozContext _context;

        public ForumService(GhiasAmoozContext context)
        {
            _context=context;
        }

        public void AddAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        public int AddQuestion(Question question)
        {
            question.CreateDate = DateTime.Now;
            question.ModifiedDate = DateTime.Now;
            _context.Add(question);
            _context.SaveChanges();
            return question.QuestionId;
        }

        public void ChangeIsTrueAnswer(int questionId, int answerId)
        {
            var answers = _context.Answers.Where(a => a.QuestionId == questionId);
            foreach (var ans in answers)
            {
                ans.IsTrue = false;
                if (ans.AnswerId == answerId)
                {
                    ans.IsTrue = true;
                }
            }
            _context.UpdateRange(answers);
            _context.SaveChanges();
        }

        public IEnumerable<Question> GetQuestions(int? courseId, string filter = "")
        {
            IQueryable<Question> result = _context.Questions.Where(q => EF.Functions.Like(q.Title, $"%{filter}%"));
            if (courseId != null)
            {
                result = result.Where(q => q.CourseId == courseId);
            }
            return result.Include(q=>q.Course).Include(q=>q.User).ToList();
        }

        public ShowQuestionViewModel ShowQuestion(int questionId)
        { 
            var question = new ShowQuestionViewModel();
            question.Question = _context.Questions.Include(q => q.User).FirstOrDefault(q => q.QuestionId == questionId);
            question.Answers=_context.Answers.Where(a => a.QuestionId == questionId).Include(u=>u.user).ToList();
            return question;
        }
    }
}
