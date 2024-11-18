using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;   
        }

        [HttpPost]
        public IActionResult Create(TasksUser user)
        {
            if(_userService.CreateUser(user))
            {
                return Ok("success");
            }
            return NotFound();
        }
    }
}
