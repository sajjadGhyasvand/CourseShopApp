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
        #endregion

        #region Answer

        #endregion
    }
}
