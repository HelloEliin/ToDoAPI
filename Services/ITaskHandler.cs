using ToDoAPI.Models;
using Task = ToDoAPI.Models.Task;

namespace ToDoAPI.Services
{
    public interface ITaskHandler
   {
        CreateToDoList AddTask(Task task); 
        IEnumerable<Task> GetTasks(Guid id);
        Task UpdateTask(Task task);
        Task GetSingelTask(Guid id);
        Task MarkAsComplete(Task task);
        Task DeleteTask(Guid id); 
    }
}
