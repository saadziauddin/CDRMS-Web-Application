using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using CDRMS_Web_Application.Models;

namespace CDRMS_Web_Application.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<UsersModel> _signInManager;
        private readonly UserManager<UsersModel> _userManager;

        public AccountController(SignInManager<UsersModel> signInManager, UserManager<UsersModel> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        /* private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }*/

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, rememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home"); // Redirect to the home page after login
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
