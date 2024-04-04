using DoAnCoSo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DoAnCoSo.Controllers
{
    public class AdminController : Controller
    {
        private readonly LoginAction _loginAction;
        private readonly DienThoaiAction _dienThoaiAction;
        private readonly OpLungAction _opLungAction;
        private readonly UserAction _userAction;
        public AdminController(LoginAction loginAction, UserAction userAction, DienThoaiAction dienThoaiAction, OpLungAction opLungAction)
        {
            _loginAction = loginAction;
            _userAction = userAction;
            _dienThoaiAction = dienThoaiAction;
            _opLungAction = opLungAction;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User inputUser)
        {
            if (await _loginAction.CheckLoginAsyn(inputUser.Name, inputUser.Password, true))
            {
                return RedirectToAction("Index", "Home", inputUser.Name);
            }
            return View(inputUser);
        }
        //Khu vực thêm
        public IActionResult ThemDienThoai()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ThemDienThoai(DienThoai inputDienThoai)
        {
            if (/*ModelState.IsValid*/true)
            {
                await _dienThoaiAction.AddDienThoaiAsync(inputDienThoai);
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult ThemOpLung()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ThemOpLung(OpLung inputOpLung)
        {
            if (/*ModelState.IsValid*/true)
            {
                await _opLungAction.AddOpLungAsync(inputOpLung);
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult ThemUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TheUser(User inputUser)
        {
            if (/*ModelState.IsValid*/true)
            {
                await _userAction.AddUserAsync(inputUser);
                return RedirectToAction("Index", "Home");
            }
        }
        //Khu vực sửa
        public IActionResult SuaDienThoai(int ID)
        {
            return View(_dienThoaiAction.GetDienThoaiByIdAsync(ID));
        }
        [HttpPost]
        public async Task<IActionResult> SuaDienThoai(DienThoai inputDienThoai)
        {
            if (/*ModelState.IsValid*/true)
            {
                await _dienThoaiAction.UpdateDienThoaiAsync(inputDienThoai);
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult SuaOpLung(int ID)
        {
            return View(_opLungAction.GetOpLungByIdAsync(ID));
        }
        [HttpPost]
        public async Task<IActionResult> SuaOpLung(OpLung inputOpLung)
        {
            if (/*ModelState.IsValid*/true)
            {
                await _opLungAction.UpdateOpLungAsync(inputOpLung);
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult SuaUser(string userName)
        {
            return View(_userAction.GetUserAsync(userName));
        }
        [HttpPost]
        public async Task<IActionResult> SuaUser(User inputUser)
        {
            if (/*ModelState.IsValid*/true)
            {
                await _userAction.UpdateUserAsync(inputUser);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
