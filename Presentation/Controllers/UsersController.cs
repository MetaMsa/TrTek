using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public UsersController(IServiceManager manager)
        {
            _manager = manager;
        }
        
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_manager.UsersService.GetAllUsers());
        }
    }
}