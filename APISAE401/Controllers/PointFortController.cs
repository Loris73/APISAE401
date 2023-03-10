using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIFilms.Models.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APISAE401.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PointFortController : ControllerBase
    {

        private readonly MedDBContext _context;

        public PointFortController(MedDBContext context)
        {
            _context = context;
        }

        // GET: api/PointFort
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<PointFort>>> GetPointForts()
        {
            return await _context.PointFort.ToListAsync();
        }

        // GET: api/PointFort/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        public async Task<ActionResult<PointFort>> GetPointFortById(int id)
        {
            var pointFort = await _context.PointFort.FindAsync(id);

            if (pointFort == null)
            {
                return NotFound();
            }

            return pointFort;
        }


        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ActionName("Put")]
        public async Task<IActionResult> PutPointFort(int id, PointFort pointFort)
        {
            if (id != pointFort.IdPointFort)
            {
                return BadRequest();
            }

            _context.Entry(pointFort).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointFortExists(id))
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

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ActionName("Post")]
        public async Task<ActionResult<PointFort>> PostPointFort(Utilisateur pointFort)
        {
            _context.PointFort.Add(pointFort);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPointFort", new { id = pointFort.IdPointFort }, pointFort);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePointFort(int id)
        {
            var pointFort = await _context.PointFort.FindAsync(id);
            if (pointFort == null)
            {
                return NotFound();
            }

            _context.PointFort.Remove(pointFort);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PointFortExists(int id)
        {
            return _context.PointFort.Any(e => e.IdPointFort == id);
        }
    }
}