using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public class UserHandler : IUserHandler
    {
        private readonly ToDoListDBContext _dbContext;
        public UserHandler(ToDoListDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public CreateUser CreateUser(CreateUser user)  
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public CreateUser DeleteUser (Guid id)
        {
            var deleteUser = _dbContext.User.FirstOrDefault(x => x.Id == id);
            _dbContext.User.Remove(deleteUser);
            _dbContext.SaveChanges();
            return deleteUser;
        }

        public CreateUser GetOneUser(Guid id)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.Id == id);
            return user;
        }
        public IEnumerable<CreateUser> GetUsers()                       
        {
            return _dbContext.User.ToList();
        }

        public CreateUser EditProfile(CreateUser user)    
        {
            CreateUser theUser = _dbContext.User.FirstOrDefault(x => x.UserName == user.UserName);
            theUser.FirstName = user.FirstName ?? theUser.FirstName;
            theUser.LastName = user.LastName ?? theUser.LastName;
            theUser.Email = user.Email ?? theUser.Email;
            theUser.Password = user.Password ?? theUser.FirstName;
            theUser.UserName = user.UserName ?? theUser.UserName;
            _dbContext.SaveChanges();
            return user;
        }


        public CreateUser Authenticate(CreateUser user)        
        {
            var theUser = _dbContext.User.SingleOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            UserDictionary.userId["UserId"] = theUser.Id.ToString(); 
            return theUser;
        }

        public CreateUser ChangeAccess(CreateUser user)
        {
            var updatedUser = _dbContext.User.FirstOrDefault(x => x.Id == user.Id);
            updatedUser.Access = user.Access;
            _dbContext.SaveChanges();
            return updatedUser;
        }

        public CreateUser GetCurrentUser()
        {
            var currentUserId = Guid.Parse(UserDictionary.userId["UserId"]);
            var theUser = _dbContext.User.SingleOrDefault(x => x.Id == currentUserId);

            return theUser;
        }


    }
}
