using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemburshmentAPI.DataBase;

namespace RemburshmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpTypesController : ControllerBase
    {
        private readonly RemContext _context;

        public SignUpTypesController(RemContext context)
        {
            _context = context;
        }

        // GET: api/SignUpTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SignUpType>>> GetSignUpType()
        {
            return await _context.SignUpType.ToListAsync();
        }

        // GET: api/SignUpTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SignUpType>> GetSignUpType(int id)
        {
            var signUpType = await _context.SignUpType.FindAsync(id);

            if (signUpType == null)
            {
                return NotFound();
            }

            return signUpType;
        }

        // PUT: api/SignUpTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSignUpType(int id, SignUpType signUpType)
        {
            if (id != signUpType.ID)
            {
                return BadRequest();
            }

            _context.Entry(signUpType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignUpTypeExists(id))
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

        // POST: api/SignUpTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SignUpType>> PostSignUpType(SignUpType signUpType)
        {
            _context.SignUpType.Add(signUpType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSignUpType", new { id = signUpType.ID }, signUpType);
        }

        // DELETE: api/SignUpTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SignUpType>> DeleteSignUpType(int id)
        {
            var signUpType = await _context.SignUpType.FindAsync(id);
            if (signUpType == null)
            {
                return NotFound();
            }

            _context.SignUpType.Remove(signUpType);
            await _context.SaveChangesAsync();

            return signUpType;
        }

        private bool SignUpTypeExists(int id)
        {
            return _context.SignUpType.Any(e => e.ID == id);
        }
    }
}
