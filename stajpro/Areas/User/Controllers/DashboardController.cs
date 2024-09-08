using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stajpro.Models;
using Entities.Dtos;
using Services.Contracts;
using Entities.Models;

namespace stajpro.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController : Controller
    {
        private readonly IServiceManager _manager;

        public DashboardController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}