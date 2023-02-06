using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using ToDoAPI.Models;
using ToDoAPI.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;


namespace ToDoAPI.Controllers
{
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
            try
            {
                return Ok(_listHandler.ViewOneList(id));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost("CreateNewToDoList")] 
        public IActionResult CreateNewToDoList(CreateToDoList list)
        {
            try
            {

            return Ok(_listHandler.CreateNewToDoList(list));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpGet("GetAllLists")] 
        public IActionResult Get()
        {
            try
            {
            return Ok(_listHandler.GetLists());

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }



        [HttpGet("GetWeeklyLists")]  
        public IActionResult GetFinishedLists()
        {
            try
            {
            return Ok(_listHandler.GetWeekly());

            }
            catch (Exception)
            {

               return BadRequest();
            }
        }


        [HttpGet("GetExpiredLists")]
        public IActionResult GetExpiredLists()
        {
            try
            {
            return Ok(_listHandler.GetExpiredLists());

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("GetCurrentUsersLists")]
        public IActionResult GetCurrentUserLists()
        {
            try
            {
            return Ok(_listHandler.GetCurrentUsersLists());

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("EditList")]
        public IActionResult Put(CreateToDoList list)
        {
            try
            {
            return Ok(_listHandler.UpdateList(list)); 

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("DeleteList/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
            return Ok(_listHandler.DeleteList(id));

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }





    }
}
