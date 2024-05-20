using DiscussionForum.Helper;
using DiscussionForum.Models;
using DiscussionForum.Services;
using DiscussionForum.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiscussionForum.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly UserManager<ApplicationUser> _userManger;
        public QuestionController(IQuestionService questionService, UserManager<ApplicationUser> userManager)
        {
            _userManger = userManager;
            _questionService = questionService;
        }
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 1)
        {

            var result = await _questionService.GetAllAsync(pageSize, pageIndex);
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(QuestionRequestVM questionRequestVM)
        {
            if (!ModelState.IsValid)
            {
                return View(questionRequestVM);
            }
            var userId = _userManger.GetUserId(User);
            Question question = questionRequestVM.ToQuestion();
            question.UserID = userId!;
            await _questionService.AddAsync(question);
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _questionService.DeleteAsync(id);


            return RedirectToAction(nameof(Index));

        }

    }
}
