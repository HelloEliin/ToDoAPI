using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskHandler _taskHandler;

        public TaskController(ITaskHandler taskHandler)
        {
            _taskHandler = taskHandler;

        }

        [HttpPost("AddTask")]    //Funkar
        public IActionResult AddTask(ToDoAPI.Models.Task task)
        {
            return Ok(_taskHandler.AddTask(task));
        }

        [HttpPost("GetTasks")]  //Oklart om den behöcs
        public IActionResult GetTasks(Guid id)
        {
            return Ok(_taskHandler.GetTasks(id));
        }

        [HttpPut("UpdateTask")]  //Funkar
        public IActionResult EditTaskName(ToDoAPI.Models.Task task)
        {
            return Ok(_taskHandler.UpdateTask(task));
        }


        [HttpGet("GetSingleTask/{id}")]  //Funkar 
        public IActionResult Get(Guid id)
        {
            return Ok(_taskHandler.GetSingelTask(id));
        }

        [HttpDelete("DeleteTask/{id}")]  //Funkar
        public IActionResult DeleteTask(Guid id)
        {
           
            return Ok(_taskHandler.DeleteTask(id));
        }

        [HttpPut("Completed")]   //Funkar
        public IActionResult MarkAsComplete()
        {
            var task = Request.ReadFromJsonAsync<ToDoAPI.Models.Task>().Result;

            try
            {
                return Ok(_taskHandler.MarkAsComplete(task));
            }
            catch (Exception e) when (e.InnerException is InvalidOperationException)
            {
                return BadRequest("Username and Password is required");
            }
            catch (Exception e) when (e.InnerException is UnauthorizedAccessException)
            {
                return BadRequest("Invalid login");
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with creating the token");
            }
          
        }


    }
}

