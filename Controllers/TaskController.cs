using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskHandler _taskHandler;

        public TaskController(ITaskHandler taskHandler)
        {
            _taskHandler = taskHandler;

        }

        [HttpPost("AddTask")]    
        public IActionResult AddTask(ToDoAPI.Models.Task task)
        {
           
            try
            {
                return Ok(_taskHandler.AddTask(task));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("GetTasks")] 
        public IActionResult GetTasks(Guid id)
        {   
            try
            {
                return Ok(_taskHandler.GetTasks(id));
            }
            catch (Exception)
            { 
                return BadRequest();
            }
        }

        [HttpPut("UpdateTask")]
        public IActionResult EditTaskName(ToDoAPI.Models.Task task)
        {           
            try
            {
                return Ok(_taskHandler.UpdateTask(task));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet("GetSingleTask/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_taskHandler.GetSingelTask(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteTask/{id}")]  
        public IActionResult DeleteTask(Guid id)
        {
            try
            {
                return Ok(_taskHandler.DeleteTask(id));
            }
            catch (Exception)
            {
               return BadRequest();
            }
        }

        [HttpPut("Completed")]   
        public IActionResult MarkAsComplete()
        {
            var task = Request.ReadFromJsonAsync<ToDoAPI.Models.Task>().Result;

            try
            {
                return Ok(_taskHandler.MarkAsComplete(task));
            }
            catch (Exception e) when (e.InnerException is InvalidOperationException)
            {
                return BadRequest();
            }
          
        }


    }
}

