using GhiasAmooz.Core.Services.Interfaces;
using GhiasAmooz.DataLayer.Entities.Question;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace GhiasAmooz.Web.Controllers
{
    public class ForumController : Controller
    {
        private IForumService _forumService;

        public ForumController(IForumService forumService)
        {
            _forumService=forumService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult CreateQuestion(int id)
        {
            Question question = new Question()
            {
                CourseId = id,
            };
            return View(question);
        }
        [HttpPost]
        public IActionResult CreateQuestion(Question question)
        {
            question.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            int questionId = _forumService.AddQuestion(question);
            return Redirect($"/Forum/ShowQuestion/{questionId}");
        }

    }
}
