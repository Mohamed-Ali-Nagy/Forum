using Microsoft.AspNetCore.Mvc;

namespace DiscussionForum.Controllers
{
    public class AnswerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
