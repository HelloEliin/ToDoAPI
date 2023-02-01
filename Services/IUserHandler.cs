using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IUserHandler
    {
        CreateUser CreateUser(CreateUser user); //Funkar
        CreateUser DeleteUser(Guid id);
        CreateUser GetOneUser(Guid id);
        IEnumerable<CreateUser> GetUsers();
        CreateUser ChangeAccess(CreateUser user);

        CreateUser EditProfile(CreateUser user);    //Funkar
        CreateUser Authenticate(CreateUser user);     //Funkar
        CreateUser GetCurrentUser();
    }
}
