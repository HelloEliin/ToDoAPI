using Microsoft.EntityFrameworkCore.Storage;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IListHandler
    {
        CreateToDoList CreateNewToDoList(CreateToDoList list);
        IEnumerable<CreateToDoList> GetLists();
        CreateToDoList DeleteList(Guid id);
        CreateToDoList UpdateList(CreateToDoList list);
        CreateToDoList ViewOneList(Guid id);
        IEnumerable<CreateToDoList> GetCurrentUsersLists();

        IEnumerable<CreateToDoList> GetWeekly();
        IEnumerable<CreateToDoList>? GetExpiredLists();
    }
}
