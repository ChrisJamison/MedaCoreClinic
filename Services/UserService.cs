   public interface IUserService
   {
       bool UserExists(string username);
       bool CreateUser(string username, string password);
   }

   public class UserService : IUserService
   {
       private readonly List<(string Username, string Password)> _users = new();

       public bool UserExists(string username)
       {
           return _users.Any(u => u.Username == username);
       }

       public bool CreateUser(string username, string password)
       {
           if (UserExists(username)) return false;

           _users.Add((username, password)); // Passwords should be hashed in production.
           return true;
       }
   }