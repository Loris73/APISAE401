using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Film.Models.EntityFramework;
using NuGet.Versioning;
using API_Film.Models.DataManager;
using API_Film.Models.Repository;

namespace APISAE401.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalendriersController : ControllerBase
    {
        
        private readonly IDataRepository<Calendrier> datatRepository;

        public CalendriersController(IDataRepository<Calendrier> dataRepo)
        {
            datatRepository = dataRepo;
        }

        // GET: api/Calendriers
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Calendrier>>> GetCalendriers()
        {
            return await datatRepository.GetAll();
        }

        // GET: api/Calendriers/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Calendrier>> GetCalendrierById(int id)
        {
            var calendrier = await datatRepository.GetByIdAsync(id);

            if (calendrier == null || calendrier.Value == null)
            {
                return NotFound();
            }

            return calendrier;
        }


      

        // PUT: api/Calendriers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ActionName("Put")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCalendrier(int id, Calendrier calendrier)
        {
            if (id != calendrier.CalendrierId)
            {
                return BadRequest();
            }

            var userToUpdate = await datatRepository.GetByIdAsync(id);
            if(userToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await datatRepository.UpdateAsync(userToUpdate.Value, calendrier);
                return NoContent();
            }

        }

        // POST: api/Calendriers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ActionName("Post")]
        public async Task<ActionResult<Calendrier>> PostCalendrier(Calendrier calendrier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await datatRepository.AddAsync(calendrier);
            

            return CreatedAtAction("GetById", new { id = calendrier.DateCal }, calendrier);
        }

        // DELETE: api/Calendriers/5
        [HttpDelete("{id}")]
        [ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCalendrier(int id)
        {
            var calendrier =  await datatRepository.GetByIdAsync(id);
            if (calendrier == null)
            {
                return NotFound();
            }

           await datatRepository.DeleteAsync(calendrier.Value);

            return NoContent();
        }

        /*private bool CalendrierExists(int id)
        {
            return _context.Calendriers.Any(e => e.CalendrierId == id);
        }*/
    }
}