using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ToDoAPI.Models;
using Task = ToDoAPI.Models.Task;

namespace ToDoAPI.Services
{
    public class TaskHandler : ITaskHandler
    {
        private readonly ToDoListDBContext _dbContext;
        public TaskHandler(ToDoListDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CreateToDoList AddTask(Task task)   //Klart
        {
            var listID = Guid.Parse(ListDictionary.id["ListId"]);
            _dbContext.Task.Add(task);
            _dbContext.SaveChanges();
            return _dbContext.ToDoLists.Include(x => x.Task).FirstOrDefault(x => x.Id == listID);
        }


        public IEnumerable<Task> GetTasks(Guid id) //Vet ej om de behövs 
        {
            var tasks = _dbContext.Task.Where(x => x.CreateToDoListId == id);
            return tasks;
        }

        public Task UpdateTask(Task task)  //klart
        {
            var editTask = _dbContext.Task.FirstOrDefault(x => x.Id == task.Id);
            editTask.TaskTitle = task.TaskTitle;
            _dbContext.SaveChanges();
            return task;
        }


        public Task DeleteTask(Guid id) //KLar
        {
            var listID = Guid.Parse(ListDictionary.id["ListId"]);
            var deleteTask = _dbContext.Task.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(deleteTask);
            _dbContext.SaveChanges();
            return deleteTask;
        }

        public Task GetSingelTask(Guid id) //oklart om den ens behlvs
        {
            //ListDictionary.id["TaskId"] = id.ToString();
            var task = _dbContext.Task.FirstOrDefault(x => x.Id == id);
            return task;
        }


        public Task MarkAsComplete(Task task)  //klar
        {

            var theTask = _dbContext.Task.FirstOrDefault(x => x.Id == task.Id);
            theTask.Completed = true;
            _dbContext.SaveChanges();
            return task;
        }




    }

}



