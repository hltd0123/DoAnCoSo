using DoAnCoSo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnCoSo.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginAction _loginAction;
        public LoginController(LoginAction loginAction) 
        {
            _loginAction = loginAction;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User inputUser)
        {
            if (await _loginAction.CheckLoginAsyn(inputUser.Name, inputUser.Password))
            {
                return RedirectToAction("Index", "Home", inputUser.Name);
            }
            return View(inputUser);
        }
        public IActionResult SignUp()
        {
            return View(new User());
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(User inputUser)
        {
            if (await _loginAction.CheckExistAsyn(inputUser.Name, inputUser.Email))
            {
                return View(inputUser);
            }
            try
            {
                if (await _loginAction.SignInAsyn(inputUser))
                    return RedirectToAction("Index");
                return View(inputUser);
            }
            catch (Exception ex)
            {
                return View(inputUser);
            }
        }
    }
}
