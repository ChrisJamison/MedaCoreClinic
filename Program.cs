using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure services BEFORE builder.Build()
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>();

// Add the database context and connect to SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add authentication and authorization services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Redirect to login if unauthenticated
        options.LogoutPath = "/Login/Logout"; // Optional: Logout path
    });

builder.Services.AddAuthorization();


var app = builder.Build();

// Configure middleware AFTER builder.Build()
app.UseStaticFiles(); // Serve static files like CSS, JS, etc.
app.UseRouting();

app.UseAuthentication(); // Enable authentication middleware
app.UseAuthorization(); // Enable authorization middleware

// Configure endpoints
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();