using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemburshmentAPI.DataBase;
using RemburshmentAPI.Model;

namespace RemburshmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemburshmentTypeModesController : ControllerBase
    {
        private readonly RemContext _context;

        public RemburshmentTypeModesController(RemContext context)
        {
            _context = context;
        }

        // GET: api/RemburshmentTypeModes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Remburshmenttype>>> GetRemburshmentTypeMode()
        {
            var result = new List<Remburshmenttype>();
            foreach (var remburshmentType in _context.RemburshmentType)
            {
                result.Add(remburshmentType);
            }
            return result;
        }

        // GET: api/RemburshmentTypeModes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RemburshmentTypeMode>> GetRemburshmentTypeMode(int id)
        {
            var remburshmentTypeMode = await _context.RemburshmentTypeMode.FindAsync(id);
            if (remburshmentTypeMode == null)
            {
                return NotFound();
            }
            return remburshmentTypeMode;
        }

        // PUT: api/RemburshmentTypeModes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRemburshmentTypeMode(int id, RemburshmentTypeMode remburshmentTypeMode)
        {
            if (id != remburshmentTypeMode.RemburshmentID)
            {
                return BadRequest();
            }

            _context.Entry(remburshmentTypeMode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RemburshmentTypeModeExists(id))
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

        // POST: api/RemburshmentTypeModes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RemburshmentTypeMode>> PostRemburshmentTypeMode(RemburshmentTypeMode remburshmentTypeMode)
        {
            _context.RemburshmentTypeMode.Add(remburshmentTypeMode);
            await _context.SaveChangesAsync();

            return remburshmentTypeMode;// CreatedAtAction("GetRemburshmentTypeMode", new { id = remburshmentTypeMode.RemburshmentID }, remburshmentTypeMode);
        }

        // DELETE: api/RemburshmentTypeModes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RemburshmentTypeMode>> DeleteRemburshmentTypeMode(int id)
        {
            var remburshmentTypeMode = await _context.RemburshmentTypeMode.FindAsync(id);
            if (remburshmentTypeMode == null)
            {
                return NotFound();
            }

            _context.RemburshmentTypeMode.Remove(remburshmentTypeMode);
            await _context.SaveChangesAsync();

            return remburshmentTypeMode;
        }

        private bool RemburshmentTypeModeExists(int id)
        {
            return _context.RemburshmentTypeMode.Any(e => e.RemburshmentID == id);
        }
    }
}
