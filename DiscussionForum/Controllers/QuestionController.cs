using DiscussionForum.Helper;
using DiscussionForum.Services;
using DiscussionForum.ViewModels;
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
        public async Task<IActionResult> Index(int pageSize=10,int pageIndex=1)
        {
          var questions= await _questionService.GetAllAsync(pageSize,pageIndex);
          return View(questions);
        }
        public async Task<IActionResult> Add(QuestionRequestVM questionRequestVM)
        {
            if(!ModelState.IsValid) 
            {
                return View(questionRequestVM);
            }
           await _questionService.AddAsync(questionRequestVM.ToQuestion());
            return RedirectToAction(nameof(Index));
        }
    }
}
