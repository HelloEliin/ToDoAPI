using Microsoft.EntityFrameworkCore.Storage;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IListHandler 
    {
        //CreateToDoList CreateNewToDoList(string id, string listTitle);
        CreateToDoList CreateNewToDoList(CreateToDoList list);
        IEnumerable<CreateToDoList> GetLists();   //Funkar
        Guid GetRecentViewedList();
        CreateToDoList DeleteList(Guid id);
        CreateToDoList EditList(string listTitle);
        CreateToDoList ViewOneList(Guid id);
        CreateToDoList WeeklyList(Guid? id);
        IEnumerable<CreateToDoList> GetCurrentUsersLists();

        //IEnumerable<CreateToDoList> GetCurrentUsersLists(System.Security.Principal.IIdentity identity, string userId);  //Gamla
    }
}
