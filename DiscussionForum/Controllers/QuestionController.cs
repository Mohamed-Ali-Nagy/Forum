using DiscussionForum.Helper;
using DiscussionForum.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiscussionForum.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        public async Task<IActionResult> Index()
        {
          var questions= await _questionService.GetAllAsync();
          var questionsResponseVM=questions.Select(q=>q.ToQuestionRespons()).ToList();
          return View(questionsResponseVM);
        }
    }
}
