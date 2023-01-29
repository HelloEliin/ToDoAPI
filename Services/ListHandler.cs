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

        public Guid GetRecentViewedList()    //Funkar
        {
            Guid listId = Guid.Parse(ListDictionary.id["ListId"]);
            return listId;
        }

        public IEnumerable<CreateToDoList> GetLists()    //Funkar
        {
            return _dbContext.ToDoLists.ToList();
        }

        public CreateToDoList CreateNewToDoList(CreateToDoList list) // nya, funkar
        {
            ListDictionary.id["ListId"] = list.Id.ToString();
            Guid listId = Guid.Parse(ListDictionary.id["ListId"]);
            list.CreateUserId = Guid.Parse(UserDictionary.userId["UserId"]);
            _dbContext.ToDoLists.Add(list);
            _dbContext.SaveChanges();
            return list;
        }


        public CreateToDoList DeleteList(Guid id)   //Funkar
        {

            //var listID = Guid.Parse(ListDictionary.id["ListId"]);
            var deleteList = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(deleteList);
            _dbContext.SaveChanges();
            return deleteList;
        }
        //public void DeleteList(Guid? id)
        //{
        //    if (id == null)
        //    {

        //        var selectedList = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == listID);
        //        _dbContext.ToDoLists.Remove(selectedList);
        //        _dbContext.SaveChanges();
        //        return;
        //    }
        //    else
        //    {
        //        var selectedList = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
        //        _dbContext.ToDoLists.Remove(selectedList);
        //        _dbContext.SaveChanges();
        //        return;
        //    }
        //}

        public CreateToDoList EditList(string listTitle)
        {
            var listID = Guid.Parse(ListDictionary.id["ListId"]);
            var list = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == listID);
            list.ListTitle = listTitle;            
            _dbContext.SaveChanges();
            return list;
        }


        public CreateToDoList ViewOneList(Guid id)   //Funkar
        {
            ListDictionary.id["ListId"] = id.ToString();
            var list = _dbContext.ToDoLists.Include(x => x.Task).FirstOrDefault(x => x.Id == id);
            return list;
        }

        public IEnumerable<CreateToDoList> GetCurrentUsersLists()   //Funkar, slår unreq
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
