using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsCollations.Models;

namespace StudentsCollations.Controllers
{
    public class StudentManiesController : Controller
    {
        private readonly Ktjune23Context _context;

        public StudentManiesController(Ktjune23Context context)
        {
            _context = context;
        }

        // GET: StudentManies
        public async Task<IActionResult> Index()
        {
              return _context.StudentManies != null ? 
                          View(await _context.StudentManies.ToListAsync()) :
                          Problem("Entity set 'Ktjune23Context.StudentManies'  is null.");
        }

        // GET: StudentManies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentManies == null)
            {
                return NotFound();
            }

            var studentMany = await _context.StudentManies
                .FirstOrDefaultAsync(m => m.StuId == id);
            if (studentMany == null)
            {
                return NotFound();
            }

            return View(studentMany);
        }

        // GET: StudentManies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentManies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StuId,StuName,StuSurName,StuEmail,StuPhoneNo,StuCourse,StuCourseFees")] StudentMany studentMany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentMany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentMany);
        }

        // GET: StudentManies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentManies == null)
            {
                return NotFound();
            }

            var studentMany = await _context.StudentManies.FindAsync(id);
            if (studentMany == null)
            {
                return NotFound();
            }
            return View(studentMany);
        }

        // POST: StudentManies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StuId,StuName,StuSurName,StuEmail,StuPhoneNo,StuCourse,StuCourseFees")] StudentMany studentMany)
        {
            if (id != studentMany.StuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentMany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentManyExists(studentMany.StuId))
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
            return View(studentMany);
        }

        // GET: StudentManies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentManies == null)
            {
                return NotFound();
            }

            var studentMany = await _context.StudentManies
                .FirstOrDefaultAsync(m => m.StuId == id);
            if (studentMany == null)
            {
                return NotFound();
            }

            return View(studentMany);
        }

        // POST: StudentManies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentManies == null)
            {
                return Problem("Entity set 'Ktjune23Context.StudentManies'  is null.");
            }
            var studentMany = await _context.StudentManies.FindAsync(id);
            if (studentMany != null)
            {
                _context.StudentManies.Remove(studentMany);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentManyExists(int id)
        {
          return (_context.StudentManies?.Any(e => e.StuId == id)).GetValueOrDefault();
        }
    }
}
