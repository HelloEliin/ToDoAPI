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

        //[AllowAnonymous]
        //[HttpPost("CreateUser")]
        //public IActionResult CreateUser(string firstname, string lastname, string username, string email, string password)
        //{
        //    return Ok(_userHandler.CreateUser(firstname, lastname, username, email, password));  // vanliga
        //}


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



        //[AllowAnonymous]
        //[HttpPost("DeleteUser")]
        //public IActionResult DeleteUser()
        //{
        //   var user = Request.ReadFromJsonAsync<CreateUser>().Result;

        //    try
        //    {
        //        return Ok(_userHandler.DeleteUser(user).Result);
        //    }
        //    catch (Exception e) when (e.InnerException is InvalidOperationException)
        //    {
        //        return BadRequest("Username and Password is required");
        //    }
        //    catch (Exception e) when (e.InnerException is UnauthorizedAccessException)
        //    {
        //        return BadRequest("Invalid login");
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Something went wrong with creating the token");
        //    }
        //    //if (user == null)
        //    //{
        //    //    user = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
        //    //}

        //}


        [HttpGet("GetOneUser/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_userHandler.GetOneUser(id));
        }


        [AllowAnonymous]
        [HttpGet("GetAllUsers")]
        public IActionResult Get()
        {
            return Ok(_userHandler.GetUsers());
        }


        [AllowAnonymous]
        [HttpPut("EditProfile")]
        public IActionResult EditProfile()
        {

            var user = Request.ReadFromJsonAsync<CreateUser>().Result;
            return Ok(_userHandler.EditProfile(user));

        }


        [HttpPut("ChangeAccess/{id}")]
        public IActionResult ChangeAccess(Guid id, Access access)
        {
            return Ok(_userHandler.ChangeAccess(id, access));
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
