
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Authorize]
public class SchedulesController : Controller
{
    private readonly ApplicationDbContext _context;

    public SchedulesController(ApplicationDbContext context)
    {
        _context = context;
    }
        
    public async Task<IActionResult> Index(int page)
    {
        var schedules = await _context.Schedules.ToListAsync();

        // Optional: Add pagination logic here.
        const int pageSize = 5;
        var paginatedSchedules = schedules.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling((double)schedules.Count / pageSize);

        return View(paginatedSchedules);
    }
    // Add New (Thêm Mới) functionality
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Schedule());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Schedule schedule, string TimeString)
    {

        if (TimeSpan.TryParse(TimeString, out var time))
        {
            schedule.Time = time; // Assign the parsed TimeSpan to the model
        }
        if (ModelState.IsValid)
        {
            _context.Add(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(schedule);
    }
    
    // GET: Edit
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var patient = await _context.Patients.FindAsync(id);
        if (patient == null) return NotFound();

        return View(patient);
    }

    // POST: Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Patient patient)
    {
        if (id != patient.Id) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(patient);
    }

    // GET: Delete
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var patient = await _context.Patients.FindAsync(id);
        if (patient == null) return NotFound();

        return View(patient);
    }

    // POST: Delete
    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient != null)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}