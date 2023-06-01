using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskMasterBusinessObjects;

namespace WebFormTaskMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjStatusController : ControllerBase
    {
        private readonly TaskMasterDBContext _context;

        public ProjStatusController(TaskMasterDBContext context)
        {
            _context = context;
        }

        // GET: api/ProjStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjStatus>>> GetProjStatuses()
        {
          if (_context.ProjStatuses == null)
          {
              return NotFound();
          }
            return await _context.ProjStatuses.ToListAsync();
        }

        // GET: api/ProjStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjStatus>> GetProjStatus(int id)
        {
          if (_context.ProjStatuses == null)
          {
              return NotFound();
          }
            var projStatus = await _context.ProjStatuses.FindAsync(id);

            if (projStatus == null)
            {
                return NotFound();
            }

            return projStatus;
        }

        // PUT: api/ProjStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjStatus(int id, ProjStatus projStatus)
        {
            if (id != projStatus.StatusId)
            {
                return BadRequest();
            }

            _context.Entry(projStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProjStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjStatus>> PostProjStatus(ProjStatus projStatus)
        {
          if (_context.ProjStatuses == null)
          {
              return Problem("Entity set 'TaskMasterDBContext.ProjStatuses'  is null.");
          }
            _context.ProjStatuses.Add(projStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjStatus", new { id = projStatus.StatusId }, projStatus);
        }

        // DELETE: api/ProjStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjStatus(int id)
        {
            if (_context.ProjStatuses == null)
            {
                return NotFound();
            }
            var projStatus = await _context.ProjStatuses.FindAsync(id);
            if (projStatus == null)
            {
                return NotFound();
            }

            _context.ProjStatuses.Remove(projStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjStatusExists(int id)
        {
            return (_context.ProjStatuses?.Any(e => e.StatusId == id)).GetValueOrDefault();
        }
    }
}
