using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Services
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var totalServices = _context.Services.Count();
            var services = _context.Services
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalServices / pageSize);

            return View(services);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: Services/Edit/5
        public IActionResult Edit(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Services/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Services.Update(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var service = _context.Services.Find(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}