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
    public class DashboardModelsController : ControllerBase
    {
        private readonly RemContext _context;

        public DashboardModelsController(RemContext context)
        {
            _context = context;
        }


        // GET: api/DashboardModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DashboardModel>>> GetDashboardModel()
        {
            var re = (from d in _context.Dashboard
                      where d.Status.Equals("To be Processed")
                      select new DashboardModel()
                      {
                          ID = d.ID,
                          ApprovedBy = d.ApprovedBy,
                          Date = d.Date,
                          RequestedValue = d.RequestedValue,
                          RemburshmentID = d.RemburshmentID,

                          CurrencyID = d.CurrencyID,

                          Image = d.Image,
                          Status = d.Status,
                          Note = d.Note,
                          ApprovedValue = d.ApprovedValue,
                          Email = d.Email,
                      }).ToList();

            var result = (from d in re
                          join
                          c in _context.CurrencyType on d.CurrencyID equals c.CurrencyID
                          join
                          r in _context.RemburshmentType on d.RemburshmentID equals r.RemburshmentID
                          select new DashboardModel()
                          {
                              ID = d.ID,
                              ApprovedBy = d.ApprovedBy,
                              Date = d.Date,
                              RequestedValue = d.RequestedValue,
                              RemburshmentID = d.RemburshmentID,
                              RemburshmentType = r.RemburshmentType,
                              CurrencyID = d.CurrencyID,
                              CurrencyType = c.CurrencyType,
                              Image = d.Image,
                              Status = d.Status,
                              Note = d.Note,
                              ApprovedValue = d.ApprovedValue,
                              Email = d.Email,
                          }).ToList();
           
            return result;
               
        }

        

        // GET: api/DashboardModels/p.p.vns76@gmail.com
        [HttpGet("{Email}")]
        public async Task<ActionResult<IEnumerable<DashboardModel>>> GetDashboardModel(string Email)
        {
            
            //var dashboard = await _context.Dashboard.ToListAsync();
            var re = (from d in _context.Dashboard where d.Email == Email
                      select new DashboardModel()
                      {
                          ID = d.ID,
                          ApprovedBy = d.ApprovedBy,
                          Date = d.Date,
                          RequestedValue = d.RequestedValue,
                          RemburshmentID = d.RemburshmentID,
                          
                          CurrencyID = d.CurrencyID,
                          
                          Image = d.Image,
                          Status = d.Status,
                          Note = d.Note,
                          ApprovedValue = d.ApprovedValue,
                          Email = d.Email,
                      }).ToList();
            var result = (from d in re
                          join
                          c in _context.CurrencyType on d.CurrencyID equals c.CurrencyID
                          join
                          r in _context.RemburshmentType on d.RemburshmentID equals r.RemburshmentID
                          select new DashboardModel()
                          {
                              ID = d.ID,
                              ApprovedBy = d.ApprovedBy,
                              Date = d.Date,
                              RequestedValue = d.RequestedValue,
                              RemburshmentID = d.RemburshmentID,
                              RemburshmentType = r.RemburshmentType,
                              CurrencyID = d.CurrencyID,
                              CurrencyType = c.CurrencyType,
                              Image = d.Image,
                              Status = d.Status,
                              Note = d.Note,
                              ApprovedValue = d.ApprovedValue,
                              Email = d.Email,
                          }).ToList();
            return  result;
        }

        // PUT: api/DashboardModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDashboardModel(int id, DashBoard dashboardModel)
        {
            /*
            if (id != dashboardModel.ID)
            {
                return BadRequest();
            }*/

            _context.Entry(dashboardModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DashBoardExists(id))
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

        // POST: api/DashboardModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DashBoard>> PostDashboardModel(DashBoard dashboardModel)
        {
            _context.Dashboard.Add(dashboardModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDashboardModel", new { id = dashboardModel.ID }, dashboardModel);
        }

        // DELETE: api/DashboardModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteDashboardModel(int id)
        {
            var dashboardModel = await _context.Dashboard.FindAsync(id);
            if (dashboardModel == null)
            {
                return NotFound();
            }

            _context.Dashboard.Remove(dashboardModel);
            await _context.SaveChangesAsync();

            return dashboardModel.ID;
        }

        private bool DashBoardExists(int id)
        {
            return _context.DashboardModel.Any(e => e.ID == id);
        }
    }
}
