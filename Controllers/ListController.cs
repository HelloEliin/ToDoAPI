﻿using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("ShowList/{id}")]  //Funkar
        public IActionResult Get(Guid id)
        {
            return Ok(_listHandler.ViewOneList(id));
        }

        [HttpGet("ViewSingleList")]
        public IActionResult GetRecentViewedList()   // funkar
        {
            return Ok(_listHandler.GetRecentViewedList());
        }

        [HttpPost("CreateNewToDoList")]  //Funkar
        public IActionResult CreateNewToDoList(CreateToDoList list)
        {
            return Ok(_listHandler.CreateNewToDoList(list));
        }


        [HttpGet("GetAllLists")]  //Funkar
        public IActionResult Get()
        {
          
            return Ok(_listHandler.GetLists());
        }

        [HttpGet("GetCurrentUsersLists")]
        public IActionResult GetCurrentUserLists()
        {
            return Ok(_listHandler.GetCurrentUsersLists());
        }

        [HttpPut("EditList")]
        public IActionResult Put(string listTitle)
        {
            return Ok(_listHandler.EditList(listTitle)); 
        }

        [HttpDelete("DeleteList/{id}")]
        public IActionResult Delete(Guid id)
        {
            _listHandler.DeleteList(id);
            return Ok();
        }


        [HttpPut("WeeklyList")]
        public IActionResult WeeklyList(Guid? id)
        {

            return Ok(_listHandler.WeeklyList(id));
        }



    }
}
