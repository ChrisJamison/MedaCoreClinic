using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: List users
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
        
        // Add New (Thêm Mới) functionality
        [HttpGet]
        public IActionResult Create()
        {
            return View(new User());
        }

        // POST: Create a new user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Check for duplicate Username/Email
                if (_context.Users.Any(u => u.Email == user.Email || u.Username == user.Username))
                {
                    TempData["Error"] = "Username hoặc Email đã tồn tại!";
                    return RedirectToAction(nameof(Index));
                }

                _context.Users.Add(user);
                _context.SaveChanges();
                TempData["Message"] = "Thêm tài khoản thành công!";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Vui lòng nhập thông tin hợp lệ!";
            return RedirectToAction(nameof(Index));
        }

        // POST: Delete a user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                TempData["Error"] = "Không tìm thấy tài khoản!";
                return RedirectToAction(nameof(Index));
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            TempData["Message"] = "Xóa tài khoản thành công!";
            return RedirectToAction(nameof(Index));
        }

        // POST: Edit a user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                TempData["Message"] = "Cập nhật tài khoản thành công!";
            }
            else
            {
                TempData["Error"] = "Thông tin nhập chưa hợp lệ!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}