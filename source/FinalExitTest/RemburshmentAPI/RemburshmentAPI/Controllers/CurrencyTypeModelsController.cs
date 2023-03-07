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
    public class CurrencyTypeModelsController : ControllerBase
    {
        private readonly RemContext _context;

        public CurrencyTypeModelsController(RemContext context)
        {
            _context = context;
        }

        // GET: api/CurrencyTypeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyTypeModel>>> GetCurrencyTypeModel()
        {
            //return await _context.CurrencyType.ToListAsync();
            var result = new List<CurrencyTypeModel>();
           
            foreach(var i in _context.CurrencyType)
            {
                result.Add(
                    
                        new CurrencyTypeModel()
                        {
                            CurrencyID=i.CurrencyID,
                            CurrencyType=i.CurrencyType,
                        }
                    );
            }

            return  result;

                
        }

        // GET: api/CurrencyTypeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrencyTypeModel>> GetCurrencyTypeModel(int id)
        {
            var currencyTypeModel = await _context.CurrencyTypeModel.FindAsync(id);

            if (currencyTypeModel == null)
            {
                return NotFound();
            }

            return currencyTypeModel;
        }

        // PUT: api/CurrencyTypeModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrencyTypeModel(int id, CurrencyTypeModel currencyTypeModel)
        {
            if (id != currencyTypeModel.CurrencyID)
            {
                return BadRequest();
            }

            _context.Entry(currencyTypeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyTypeModelExists(id))
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

        // POST: api/CurrencyTypeModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CurrencyTypeModel>> PostCurrencyTypeModel(CurrencyTypeModel currencyTypeModel)
        {
            _context.CurrencyTypeModel.Add(currencyTypeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrencyTypeModel", new { id = currencyTypeModel.CurrencyID }, currencyTypeModel);
        }

        // DELETE: api/CurrencyTypeModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CurrencyTypeModel>> DeleteCurrencyTypeModel(int id)
        {
            var currencyTypeModel = await _context.CurrencyTypeModel.FindAsync(id);
            if (currencyTypeModel == null)
            {
                return NotFound();
            }

            _context.CurrencyTypeModel.Remove(currencyTypeModel);
            await _context.SaveChangesAsync();

            return currencyTypeModel;
        }

        private bool CurrencyTypeModelExists(int id)
        {
            return _context.CurrencyTypeModel.Any(e => e.CurrencyID == id);
        }
    }
}
