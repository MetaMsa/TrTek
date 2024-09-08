using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stajpro.Models;
using Entities.Dtos;
using Services.Contracts;
using Entities.Models;

namespace stajpro.Areas.User.Controllers
{
    [Area("User")]
    public class GetEventController : Controller
    {
        private readonly IServiceManager _manager;

        public GetEventController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Get([FromRoute (Name = "id")] int id)
        {
            var model = _manager.EventsService.GetOneEvents(id, false);
            return View("Index", model);
        }
    }
}