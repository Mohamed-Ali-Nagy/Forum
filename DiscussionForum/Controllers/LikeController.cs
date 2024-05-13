using Microsoft.AspNetCore.Mvc;

namespace DiscussionForum.Controllers
{
    public class LikeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
