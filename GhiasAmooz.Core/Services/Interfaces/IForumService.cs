using GhiasAmooz.Core.DTOs;
using GhiasAmooz.DataLayer.Entities.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhiasAmooz.Core.Services.Interfaces
{
    public interface IForumService
    {
        #region Question
        int AddQuestion(Question question);
        ShowQuestionViewModel ShowQuestion(int questionId);
        IEnumerable<Question> GetQuestions(int? courseId,string filter="");
        #endregion

        #region Answer
        void AddAnswer(Answer answer);
        void ChangeIsTrueAnswer(int questionId,int answerId);
        #endregion


    }
}
