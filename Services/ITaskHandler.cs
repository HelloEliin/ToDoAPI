using ToDoAPI.Models;
using Task = ToDoAPI.Models.Task;

namespace ToDoAPI.Services
{
    public interface ITaskHandler
    {
        CreateToDoList AddTask(Task task);  //Funkar
        IEnumerable<Task> GetTasks(Guid id);
        Task UpdateTask(Task task);
        Task GetSingelTask(Guid id);

        Task MarkAsComplete(Task task);
        //CreateToDoList CreateNewToDoList(string listTitle);
        //IEnumerable<CreateToDoList> GetLists();
        Task DeleteTask(Guid id); //Funkar
        //CreateToDoList ChangeTaskName(int id, string value);
    }
}
