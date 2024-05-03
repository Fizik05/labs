using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Third_laba.Data;
using Third_laba.Models;

namespace Third_laba.Controllers
{
    public class AchievementCatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AchievementCatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AchievementCats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AchievementCat.Include(a => a.Achievement).Include(a => a.Cat);
            return new JsonResult(await applicationDbContext.ToListAsync());
        }

        // GET: AchievementCats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AchievementCat == null)
            {
                return NotFound();
            }

            var achievementCat = await _context.AchievementCat
                .Include(a => a.Achievement)
                .Include(a => a.Cat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (achievementCat == null)
            {
                return NotFound();
            }

            return View(achievementCat);
        }

        // GET: AchievementCats/Create
        public IActionResult Create()
        {
            ViewData["AchievementId"] = new SelectList(_context.Achievements, "Id", "Title");
            ViewData["CatId"] = new SelectList(_context.Cats, "Id", "Id");
            return View();
        }

        // POST: AchievementCats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CatId,AchievementId")] AchievementCat achievementCat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(achievementCat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            foreach (var key in ModelState.Keys)
            {
                var errors = ModelState[key].Errors;
                if (errors.Any())
                {
                    Console.WriteLine($"Property '{key}' has validation errors:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error.ErrorMessage}");
                    }
                }
            }


            ViewData["AchievementId"] = new SelectList(_context.Achievements, "Id", "Title", achievementCat.AchievementId);
            ViewData["CatId"] = new SelectList(_context.Cats, "Id", "Id", achievementCat.CatId);
            return View(achievementCat);
        }

        // GET: AchievementCats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AchievementCat == null)
            {
                return NotFound();
            }

            var achievementCat = await _context.AchievementCat.FindAsync(id);
            if (achievementCat == null)
            {
                return NotFound();
            }
            ViewData["AchievementId"] = new SelectList(_context.Achievements, "Id", "Title", achievementCat.AchievementId);
            ViewData["CatId"] = new SelectList(_context.Cats, "Id", "Id", achievementCat.CatId);
            return View(achievementCat);
        }

        // POST: AchievementCats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CatId,AchievementId")] AchievementCat achievementCat)
        {
            if (id != achievementCat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(achievementCat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AchievementCatExists(achievementCat.Id))
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
            ViewData["AchievementId"] = new SelectList(_context.Achievements, "Id", "Title", achievementCat.AchievementId);
            ViewData["CatId"] = new SelectList(_context.Cats, "Id", "Id", achievementCat.CatId);
            return View(achievementCat);
        }

        // GET: AchievementCats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AchievementCat == null)
            {
                return NotFound();
            }

            var achievementCat = await _context.AchievementCat
                .Include(a => a.Achievement)
                .Include(a => a.Cat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (achievementCat == null)
            {
                return NotFound();
            }

            return View(achievementCat);
        }

        // POST: AchievementCats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AchievementCat == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AchievementCat'  is null.");
            }
            var achievementCat = await _context.AchievementCat.FindAsync(id);
            if (achievementCat != null)
            {
                _context.AchievementCat.Remove(achievementCat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AchievementCatExists(int id)
        {
          return (_context.AchievementCat?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
