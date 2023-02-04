using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IUserHandler
    {
        CreateUser CreateUser(CreateUser user); 
        CreateUser DeleteUser(Guid id);
        CreateUser GetOneUser(Guid id);
        IEnumerable<CreateUser> GetUsers();
        CreateUser ChangeAccess(CreateUser user);
        CreateUser EditProfile(CreateUser user);   
        CreateUser Authenticate(CreateUser user);     
        CreateUser GetCurrentUser(Guid currentUserId);
        CreateUser LogOut(CreateUser user);
    }
}
