using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using ToDoAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using Task = ToDoAPI.Models.Task;

namespace ToDoAPI.Services
{
    public class ListHandler : IListHandler
    {
        private readonly ToDoListDBContext _dbContext;
        public ListHandler(ToDoListDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CreateToDoList> GetLists()    
        {
            return _dbContext.ToDoLists.ToList();
        }

        public CreateToDoList CreateNewToDoList(CreateToDoList list) 
        {
            ListDictionary.id["ListId"] = list.Id.ToString();
            Guid listId = Guid.Parse(ListDictionary.id["ListId"]);
            list.CreateUserId = Guid.Parse(UserDictionary.userId["UserId"]);
            _dbContext.ToDoLists.Add(list);
            _dbContext.SaveChanges();
            return list;
        }


        public CreateToDoList DeleteList(Guid id)   
        {
            var deleteList = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(deleteList);
            _dbContext.SaveChanges();
            return deleteList;
        }

        public CreateToDoList UpdateList(CreateToDoList list)
        {
            var listID = Guid.Parse(ListDictionary.id["ListId"]);
            var updatedList = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == listID);
            updatedList.ListTitle = list.ListTitle;
            updatedList.ThisWeek = list.ThisWeek;   
            _dbContext.SaveChanges();
            return list;
        }


        public CreateToDoList ViewOneList(Guid id)   
        {
            ListDictionary.id["ListId"] = id.ToString();
            var list = _dbContext.ToDoLists.Include(x => x.Task).FirstOrDefault(x => x.Id == id);
            return list;
        }

        public IEnumerable<CreateToDoList> GetCurrentUsersLists()  
        {
            var userId = Guid.Parse(UserDictionary.userId["UserId"]);
            var lists = _dbContext.ToDoLists.Where(x => x.CreateUserId == userId).ToList();
            return lists;
        }


        public CreateToDoList WeeklyList(Guid? id)
        {
            if(id == null)
            {
                id = Guid.Parse(ListDictionary.id["ListId"]);
            }
            var list = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
            list.ThisWeek = true;
            _dbContext.SaveChanges();
            return list;
        }




    }
}
