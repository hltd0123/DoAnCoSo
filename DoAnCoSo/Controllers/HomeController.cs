using DoAnCoSo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoAnCoSo.Controllers
{
    public class HomeController : Controller
    {
        private readonly DienThoaiAction _dienThoaiAction;
        private readonly OpLungAction _opLungAction;

        public HomeController(DienThoaiAction dienThoaiAction, OpLungAction opLungAction)
        {
            _dienThoaiAction = dienThoaiAction;
            _opLungAction = opLungAction;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }
    }
}
