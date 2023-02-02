using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using ToDoAPI.Models;
using ToDoAPI.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;


namespace ToDoAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {

        private readonly IListHandler _listHandler;

        private ToDoListDBContext _dbContext;

        public ListController(IListHandler listHandler, ToDoListDBContext context)
        {
            _listHandler = listHandler;
            _dbContext = context;
        }

        [HttpGet("ShowList/{id}")]  
        public IActionResult Get(Guid id)
        {
            return Ok(_listHandler.ViewOneList(id));
        }


        [HttpPost("CreateNewToDoList")] 
        public IActionResult CreateNewToDoList(CreateToDoList list)
        {
            return Ok(_listHandler.CreateNewToDoList(list));
        }


        [HttpGet("GetAllLists")] 
        public IActionResult Get()
        {
          
            return Ok(_listHandler.GetLists());
        }



        [HttpGet("GetWeeklyLists")]  
        public IActionResult GetFinishedLists()
        {

            return Ok(_listHandler.GetWeekly());
        }


        [HttpGet("GetExpiredLists")]
        public IActionResult GetExpiredLists()
        {

            return Ok(_listHandler.GetExpiredLists());
        }

        [HttpGet("GetCurrentUsersLists")]
        public IActionResult GetCurrentUserLists()
        {
            return Ok(_listHandler.GetCurrentUsersLists());
        }

        [HttpPut("EditList")]
        public IActionResult Put(CreateToDoList list)
        {
            return Ok(_listHandler.UpdateList(list)); 
        }

        [HttpDelete("DeleteList/{id}")]
        public IActionResult Delete(Guid id)
        {
           
            return Ok(_listHandler.DeleteList(id));
        }





    }
}
