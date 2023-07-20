using GhiasAmooz.DataLayer.Entities.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhiasAmooz.Core.DTOs
{
    public class ShowQuestionViewModel
    {
        public Question  Question { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
