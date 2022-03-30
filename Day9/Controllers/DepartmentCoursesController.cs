#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day9.DataAccess;
using Day9.Models;

namespace Day9.Controllers
{
    public class DepartmentCoursesController : Controller
    {
        private readonly SchoolContext _context;

        public DepartmentCoursesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: DepartmentCourses
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.DepartmentsCourse.Include(d => d.Course).Include(d => d.Department);
            return View(await schoolContext.ToListAsync());
        }

        // GET: DepartmentCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentCourse = await _context.DepartmentsCourse
                .Include(d => d.Course)
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (departmentCourse == null)
            {
                return NotFound();
            }

            return View(departmentCourse);
        }

        // GET: DepartmentCourses/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Name");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name");
            return View();
        }

        // POST: DepartmentCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,CourseId")] DepartmentCourse departmentCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Name", departmentCourse.CourseId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", departmentCourse.DepartmentId);
            return View(departmentCourse);
        }

        // GET: DepartmentCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentCourse = await _context.DepartmentsCourse.FindAsync(id);
            if (departmentCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Name", departmentCourse.CourseId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", departmentCourse.DepartmentId);
            return View(departmentCourse);
        }

        // POST: DepartmentCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,CourseId")] DepartmentCourse departmentCourse)
        {
            if (id != departmentCourse.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentCourseExists(departmentCourse.DepartmentId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Name", departmentCourse.CourseId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", departmentCourse.DepartmentId);
            return View(departmentCourse);
        }

        // GET: DepartmentCourses/Delete/5
        // TODO : change params 
        public async Task<IActionResult> Delete(int? CourseId ,int? DepartmentId)
        {
            if (CourseId == null)
            {
                return NotFound();
            }

            var departmentCourse = await _context.DepartmentsCourse
                .Include(d => d.Course)
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.DepartmentId == DepartmentId);
            if (departmentCourse == null)
            {
                return NotFound();
            }

            return View(departmentCourse);
        }

        // POST: DepartmentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? CourseId, int? DepartmentId)
        {
            var departmentCourse = await _context.DepartmentsCourse.FindAsync(DepartmentId, CourseId);
            _context.DepartmentsCourse.Remove(departmentCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentCourseExists(int id)
        {
            return _context.DepartmentsCourse.Any(e => e.DepartmentId == id);
        }
    }
}
