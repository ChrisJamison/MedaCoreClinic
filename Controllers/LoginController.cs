   using Microsoft.AspNetCore.Authentication;
   using Microsoft.AspNetCore.Authentication.Cookies;
   using Microsoft.AspNetCore.Mvc;
   using System.Security.Claims;
   using Microsoft.AspNetCore.Authorization;
   using WebApplication1.Data;
   using WebApplication1.Models;
   using WebApplication1.Services;

   namespace WebApplication1.Controllers
   {
       [AllowAnonymous]
       public class LoginController : Controller
       {
           private readonly AuthService _authService;
           private readonly ApplicationDbContext _context;

           public LoginController(ApplicationDbContext context)
           {
               _authService = new AuthService();
               _context = context;
           }

           [HttpGet]
           public IActionResult Index()
           {
               return View();
           }

           [HttpPost]
           public async Task<IActionResult> Index(User user)
           {
               // // Hardcoded login credentials
               // if (user.Username == "admin" && user.Password == "admin")
               // {
               //     // If login is successful, redirect to the Patients page
               //     return RedirectToAction("Index", "Patients");
               // }
               
               var userLogin = _context.Users.FirstOrDefault(a => a.Username == user.Username && a.Password == user.Password);
               
               if (userLogin != null)
               {
                   // Create the user claims
                   var claims = new List<Claim>
                   {
                       new Claim(ClaimTypes.Name, user.Username),
                       new Claim(ClaimTypes.Role, "User") // Example role
                   };

                   // Create the identity
                   var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                   var principal = new ClaimsPrincipal(identity);

                   // Issue the authentication cookie
                   await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                   switch (userLogin.Role.Trim().ToLower())
                   {
                       // Redirect to the home page or any other actions
                       case "admin":
                           return RedirectToAction("Index", "Patients");
                       case "user":
                           return RedirectToAction("Index", "Schedules");
                   }
               }

               ViewBag.Error = "Sai thông tin đăng nhâp.";
               return View();
           }
           
           public async Task<IActionResult> Logout()
           {
               // Sign out the user
               await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
               return RedirectToAction("Index", "Login");
           }
       }
   }