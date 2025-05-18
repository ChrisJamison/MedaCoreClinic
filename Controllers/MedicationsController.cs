using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data; // Replace with your namespace
using WebApplication1.Models; // Replace with your namespace

namespace WebApplication1.Controllers // Replace with your namespace
{
    [Authorize]
    public class MedicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Medications
        public async Task<IActionResult> Index(int page)
        {
            var medications = await _context.Medications.ToListAsync();
            
            // Optional: Add pagination logic here.
            const int pageSize = 5;
            var paginatedMedications = medications.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)medications.Count / pageSize);

            return View(paginatedMedications);
        }

        // GET: Medications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }

        // GET: Medications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SerialNumber,Name,Unit,Price,HowToUse,ActiveIngredient,Concentration,Packaging,Manufacturer,Declarer")] Medication medication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medication);
        }

        // GET: Medications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medications.FindAsync(id);
            if (medication == null)
            {
                return NotFound();
            }
            return View(medication);
        }

        // POST: Medications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SerialNumber,Name,Unit,Price,HowToUse,ActiveIngredient,Concentration,Packaging,Manufacturer,Declarer")] Medication medication)
        {
            if (id != medication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationExists(medication.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medication);
        }

        // GET: Medications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }

        // POST: Medications/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medication = await _context.Medications.FindAsync(id);
            _context.Medications.Remove(medication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationExists(int id)
        {
            return _context.Medications.Any(e => e.Id == id);
        }
    }
}