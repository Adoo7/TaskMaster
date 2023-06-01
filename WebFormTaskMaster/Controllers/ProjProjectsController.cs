using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskMasterBusinessObjects;

namespace WebFormTaskMaster.Controllers
{
    public class ProjProjectsController : Controller
    {
        private readonly TaskMasterDBContext _context;

        public ProjProjectsController(TaskMasterDBContext context)
        {
            _context = context;
        }

        // GET: ProjProjects
        public async Task<IActionResult> Index()
        {
              return _context.ProjProjects != null ? 
                          View(await _context.ProjProjects.ToListAsync()) :
                          Problem("Entity set 'TaskMasterDBContext.ProjProjects'  is null.");
        }

        // GET: ProjProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjProjects == null)
            {
                return NotFound();
            }

            var projProject = await _context.ProjProjects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (projProject == null)
            {
                return NotFound();
            }

            return View(projProject);
        }

        // GET: ProjProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,Name,Description")] ProjProject projProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projProject);
        }

        // GET: ProjProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjProjects == null)
            {
                return NotFound();
            }

            var projProject = await _context.ProjProjects.FindAsync(id);
            if (projProject == null)
            {
                return NotFound();
            }
            return View(projProject);
        }

        // POST: ProjProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,Name,Description")] ProjProject projProject)
        {
            if (id != projProject.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjProjectExists(projProject.ProjectId))
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
            return View(projProject);
        }

        // GET: ProjProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjProjects == null)
            {
                return NotFound();
            }

            var projProject = await _context.ProjProjects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (projProject == null)
            {
                return NotFound();
            }

            return View(projProject);
        }

        // POST: ProjProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjProjects == null)
            {
                return Problem("Entity set 'TaskMasterDBContext.ProjProjects'  is null.");
            }
            var projProject = await _context.ProjProjects.FindAsync(id);
            if (projProject != null)
            {
                _context.ProjProjects.Remove(projProject);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjProjectExists(int id)
        {
          return (_context.ProjProjects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }
    }
}
