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
    public class SousLocalisationsController : ControllerBase
    {
        
        private readonly IDataRepository<SousLocalisation> datatRepository;

        public SousLocalisationsController(IDataRepository<SousLocalisation> dataRepo)
        {
            datatRepository = dataRepo;
        }

        // GET: api/SousLocalisations
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<SousLocalisation>>> GetSousLocalisations()
        {
            return await datatRepository.GetAll();
        }

        // GET: api/SousLocalisations/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SousLocalisation>> GetSousLocalisationById(int id)
        {
            var sousLocalisation = await datatRepository.GetByIdAsync(id);

            if (sousLocalisation == null || sousLocalisation.Value == null)
            {
                return NotFound();
            }

            return sousLocalisation;
        }


      

        // PUT: api/SousLocalisations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ActionName("Put")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutSousLocalisation(int id, SousLocalisation sousLocalisation)
        {
            if (id != sousLocalisation.SousLocalisationId)
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
                await datatRepository.UpdateAsync(userToUpdate.Value, sousLocalisation);
                return NoContent();
            }

        }

        // POST: api/SousLocalisations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ActionName("Post")]
        public async Task<ActionResult<SousLocalisation>> PostSousLocalisation(SousLocalisation sousLocalisation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await datatRepository.AddAsync(sousLocalisation);
            

            return CreatedAtAction("GetById", new { id = sousLocalisation.SousLocalisationId }, sousLocalisation);
        }

        // DELETE: api/SousLocalisations/5
        [HttpDelete("{id}")]
        [ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSousLocalisation(int id)
        {
            var sousLocalisation =  await datatRepository.GetByIdAsync(id);
            if (sousLocalisation == null)
            {
                return NotFound();
            }

           await datatRepository.DeleteAsync(sousLocalisation.Value);

            return NoContent();
        }

        /*private bool SousLocalisationExists(int id)
        {
            return _context.SousLocalisations.Any(e => e.SousLocalisationId == id);
        }*/
    }
}