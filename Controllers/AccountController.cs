using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserService _userService; // Replace with your user database/service.

        // Inject a service/repository to handle user accounts.
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the user already exists (via your user service).
                if (_userService.UserExists(model.Username))
                {
                    ModelState.AddModelError("", "This username is already taken.");
                    return View(model);
                }

                // Add the user to the database.
                var result = _userService.CreateUser(model.Username, model.Password);
                if (result)
                {
                    // Redirect to login after successful registration.
                    return RedirectToAction("Index", "Login");
                }

                ModelState.AddModelError("", "There was an error processing your request.");
            }

            return View(model);
        }
    }
}