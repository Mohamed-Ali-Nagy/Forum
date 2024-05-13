using DiscussionForum.Models;
using DiscussionForum.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiscussionForum.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser>userManager,SignInManager<ApplicationUser>signInManager )
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
 
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            var user= await _userManager.FindByNameAsync(loginVM.UserName);
            if (user != null)
            {
                var checkPassword = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (checkPassword == true)
                {
                    var result =await _signInManager.PasswordSignInAsync(user, loginVM.Password,loginVM.RememberMe,true);
                   if(result.Succeeded)
                       return RedirectToAction("Index", "Question");   
                }
            }
            ModelState.AddModelError("", "user name or password is not correct");
            return View(loginVM);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM signUpVM)
        {
            if(!ModelState.IsValid)
            {
                return View(signUpVM);
            }
            var user = await _userManager.FindByNameAsync(signUpVM.UserName);
            if (user != null)
            {
               
                return View(signUpVM);
            }
            ApplicationUser applicationUser = new ApplicationUser()
            {
                FullName=signUpVM.Name,
                Email=signUpVM.Email,
                UserName=signUpVM.UserName,
            };
            IdentityResult result=await _userManager.CreateAsync(applicationUser,signUpVM.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUser, "user");
                return RedirectToAction(nameof(LogIn));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Password", error.Description);
                }
            }
            return View(signUpVM);

        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(LogIn));
        }
    }
}
