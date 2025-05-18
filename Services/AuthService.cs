     using WebApplication1.Models;

     namespace WebApplication1.Services
     {
         public class AuthService
         {
             public bool Authenticate(User user)
             {
                 // Dummy authentication. Replace with actual logic (e.g., database verification).
                 return user.Username == "admin" && user.Password == "password";
             }
         }
     }