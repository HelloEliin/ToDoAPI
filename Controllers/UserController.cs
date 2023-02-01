using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoAPI.Models;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserHandler _userHandler;

        private ToDoListDBContext _dbContext;

        public UserController(IUserHandler userHandler, ToDoListDBContext context)
        {
            _userHandler = userHandler;
            _dbContext = context;
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public IActionResult CreateUser()                                          //Funkar
        {
            var user = Request.ReadFromJsonAsync<CreateUser>().Result;
            try
            {
                return Ok(_userHandler.CreateUser(user));
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



        [AllowAnonymous]
        [HttpDelete("DeleteUser/{id}")]  //Funkar
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                return Ok(_userHandler.DeleteUser(id));
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


        [HttpGet("ShowUser/{id}")] //Funkar
        public IActionResult Get(Guid id)
        {
            return Ok(_userHandler.GetOneUser(id));
        }


        [AllowAnonymous]
        [HttpGet("GetAllUsers")] //Funkar
        public IActionResult Get()
        {
            return Ok(_userHandler.GetUsers());
        }


        [AllowAnonymous]
        [HttpPut("EditProfile")]  //Funkar
        public IActionResult EditProfile()
        {
            var user = Request.ReadFromJsonAsync<CreateUser>().Result;
            return Ok(_userHandler.EditProfile(user));

        }


        [HttpPut("ChangeAccess")]
        public IActionResult ChangeAccess()
        {
            try
            {
                var user = Request.ReadFromJsonAsync<CreateUser>().Result;
                return Ok(_userHandler.ChangeAccess(user));
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

        [AllowAnonymous]
        [HttpGet("GetCurrentUser")]
        public IActionResult GetCurrentUser()
        {

            try
            {
                return Ok(_userHandler.GetCurrentUser());
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




        [AllowAnonymous]
        [HttpPost("LogIn")]
        public IActionResult Login()
        {
            var user = Request.ReadFromJsonAsync<CreateUser>().Result;

            try
            {
                return Ok(_userHandler.Authenticate(user));
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
