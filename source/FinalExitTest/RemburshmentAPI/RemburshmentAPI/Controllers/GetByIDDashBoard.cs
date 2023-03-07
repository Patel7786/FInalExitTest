using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemburshmentAPI.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemburshmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetByIDDashBoard : ControllerBase
    {

        private readonly RemContext _context;

        public GetByIDDashBoard(RemContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DashBoard>> GetDashboard(int id)
        {
            var signUpModel = await _context.Dashboard.FindAsync(id);
            if (signUpModel == null)
            {
                return NotFound();
            }
            return signUpModel;
        }

        [HttpPost]
        public async Task<IActionResult> PutDashboardModel(DashBoard d)
        {
            if (_context.Dashboard.Where(x => x.ID == d.ID).FirstOrDefault() != null)
            {
                _context.Entry(d).State = EntityState.Modified;
                _context.SaveChanges();
            }
            
            return NoContent();
        }
    }
}
