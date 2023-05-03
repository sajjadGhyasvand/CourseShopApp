using GhiasAmooz.Core.Services.Interfaces;
using GhiasAmooz.DataLayer.Context;
using GhiasAmooz.DataLayer.Entities.Question;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public int AddQuestion(Question question)
        {
            question.CreateDate = DateTime.Now;
            question.ModifiedDate = DateTime.Now;
            _context.Add(question);
            _context.SaveChanges();
            return question.QuestionId;
        }
    }
}
