using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemburshmentAPI.DataBase;
using RemburshmentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemburshmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeclineController : ControllerBase
    {

        private readonly RemContext _context;

        public DeclineController(RemContext context)
        {
            _context = context;
        }

        // GET: api/Decline
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DashboardModel>>> GetDashBoard()
        {
            //return await _context.Dashboard.ToListAsync();
            var re = (from d in _context.Dashboard
                      where d.Status.Equals("Decline")
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

        [HttpPost]
        public async Task<ActionResult<DashBoard>> PostDashBoard(DashBoard d)
        {
            var v = _context.Dashboard.Where(x => x.ID == d.ID).FirstOrDefault();
            if (v != null)
            {
                v.ID = d.ID;
                v.ApprovedBy = d.ApprovedBy;
                v.Date = d.Date;
                v.RequestedValue = d.RequestedValue;
                v.RemburshmentID = d.RemburshmentID;

                v.CurrencyID = d.CurrencyID;

                v.Image = d.Image;
                v.Status = "Decline";
                v.Note = d.Note;
                v.ApprovedValue = d.ApprovedValue;
                v.Email = d.Email;

                _context.Entry(v).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return NoContent();
        }
    }
}
