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
    public class SignUpController : ControllerBase
    {
        private readonly RemContext _context;
        public SignUpController(RemContext context)
        {
            _context = context;
        }

        // GET: api/SignUp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SignUpModel>>> GetSignUpModel()
        {
            //var result = await _context.SignUp.ToListAsync();
            // return result;
            var result = (from e in _context.SignUp
                          join
                          d in _context.SignUpType
                          on e.TypeID equals d.TypeID
                          select new SignUpModel
                          {
                              ID = e.ID,
                              FullName=e.FullName ,
                              PanNumber=e.PanNumber,
                              BankName=e.BankName,
                              AccountNumber=e.AccountNumber,
                              Email=e.Email,
                              Password=e.Password,
                              TypeID=e.TypeID,
                              Type=d.Type,

                          }
                        ).ToListAsync();
            return await result;

        }

        // GET: api/SignUp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SignUp>> GetSignUpModel(int id)
        {
            var signUpModel = await _context.SignUp.FindAsync(id);
            if (signUpModel == null)
            {
                return NotFound();
            }
            return signUpModel;
        }

        // PUT: api/SignUp/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSignUpModel(int id, SignUpModel signUpModel)
        {
            if (id != signUpModel.ID)
            {
                return BadRequest();
            }
            _context.Entry(signUpModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignUpModelExists(id))
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

        // POST: api/SignUp
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SignUp>> PostSignUpModel(SignUp signUpModel)
        {
            _context.SignUp.Add(signUpModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSignUpModel", new { id = signUpModel.ID }, signUpModel);
        }

        // DELETE: api/SignUp/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SignUp>> DeleteSignUpModel(int id)
        {
            var signUpModel = await _context.SignUp.FindAsync(id);
            if (signUpModel == null)
            {
                return NotFound();
            }

            _context.SignUp.Remove(signUpModel);
            await _context.SaveChangesAsync();

            return signUpModel;
        }

        private bool SignUpModelExists(int id)
        {
            return _context.SignUp.Any(e => e.ID == id);
        }
    }
}
