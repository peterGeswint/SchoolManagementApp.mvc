using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.mvc.Data;

namespace SchoolManagementApp.mvc.Controllers
{
    public class LectureClassessController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public LectureClassessController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        // GET: LectureClassess
        public async Task<IActionResult> Index()
        {
            var schoolManagementDbContext = _context.LectureClasses.Include(l => l.Course).Include(l => l.Teacher);
            return View(await schoolManagementDbContext.ToListAsync());
        }

        // GET: LectureClassess/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectureClass = await _context.LectureClasses
                .Include(l => l.Course)
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lectureClass == null)
            {
                return NotFound();
            }

            return View(lectureClass);
        }

        // GET: LectureClassess/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id");
            return View();
        }

        // POST: LectureClassess/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeacherId,CourseId,Time")] LectureClass lectureClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lectureClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", lectureClass.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", lectureClass.TeacherId);
            return View(lectureClass);
        }

        // GET: LectureClassess/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectureClass = await _context.LectureClasses.FindAsync(id);
            if (lectureClass == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", lectureClass.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", lectureClass.TeacherId);
            return View(lectureClass);
        }

        // POST: LectureClassess/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeacherId,CourseId,Time")] LectureClass lectureClass)
        {
            if (id != lectureClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lectureClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectureClassExists(lectureClass.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", lectureClass.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", lectureClass.TeacherId);
            return View(lectureClass);
        }

        // GET: LectureClassess/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectureClass = await _context.LectureClasses
                .Include(l => l.Course)
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lectureClass == null)
            {
                return NotFound();
            }

            return View(lectureClass);
        }

        // POST: LectureClassess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lectureClass = await _context.LectureClasses.FindAsync(id);
            if (lectureClass != null)
            {
                _context.LectureClasses.Remove(lectureClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LectureClassExists(int id)
        {
            return _context.LectureClasses.Any(e => e.Id == id);
        }
    }
}
