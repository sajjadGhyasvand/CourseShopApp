using Ganss.Xss;
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

        public IActionResult Index(int? courseId,string filter="")
        {
            ViewBag.CourseId = courseId;
            return View(_forumService.GetQuestions(courseId, filter));
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

        public IActionResult ShowQuestion(int id)
        {
            return View(_forumService.ShowQuestion(id));
        }
        public IActionResult Answer(int id, string body)
        {
            if (!string.IsNullOrEmpty(body))
            {
                var sanitizer = new HtmlSanitizer();
                body = sanitizer.Sanitize(body);
                _forumService.AddAnswer(new DataLayer.Entities.Question.Answer()
                {
                    BodyAnswer= body,
                    UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString()),
                    QuestionId = id,
                    CreateDate=DateTime.Now,
                });


            }
            return RedirectToAction("ShowQuestion", new
            {
                id = id
            });

        }
        [Authorize]
        public IActionResult SelectIsTrueAnswer(int questionId,int answerId)
        {
            int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var question = _forumService.ShowQuestion(questionId);
            if (question.Question.UserId == currentUserId)
            {
                _forumService.ChangeIsTrueAnswer(questionId, answerId);
            }
            return RedirectToAction("ShowQuestion", new { id = questionId });
        }
    }
}
