using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        int t = 0;
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [Route("api/Tasks/GetAllTasksWithUser")]
        [HttpGet]
        public IActionResult GetAllTasksWithUser()
        {
            var tasks = _taskService.GetAllTasksWithUser();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<List<Tasks>> Get(int id)
        {
            return _taskService.GetAllTasksByUser(id);
        }


        [Route("api/Tasks/GetAllTasksByUser_1/{userId}")]
        [HttpGet]
        public IActionResult GetAllTasksByUser_1(int userId)
        {
            var tasks= _taskService.GetAllTasksByUser(userId);
            return Ok(tasks);
        }


        [HttpDelete]
        public IActionResult Delete(Tasks task)
        {
            _taskService.DeleteTask(task);  
            return Ok("success");
        }


        [HttpPut]
        public IActionResult Update(Tasks task)
        {
            _taskService.UpdateTask(task);
            return Ok("success");
        }


        [HttpPost]
        public IActionResult Create(Tasks task)
        {
            _taskService.CreateTask(task);
            return Ok("success");
        }
    }
}
