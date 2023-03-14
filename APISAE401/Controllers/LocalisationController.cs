using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APISAE401.Models.EntityFramework;
using NuGet.Versioning;
using APISAE401.Models.DataManager;
using APISAE401.Models.Repository;

namespace APISAE401.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocalisationsController : ControllerBase
    {
        
        private readonly IDataRepository<Localisation> datatRepository;

        public LocalisationsController(IDataRepository<Localisation> dataRepo)
        {
            datatRepository = dataRepo;
        }

        // GET: api/Localisations
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Localisation>>> GetLocalisations()
        {
            return await datatRepository.GetAllAsync();
        }

        // GET: api/Localisations/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Localisation>> GetLocalisationById(int id)
        {
            var localisation = await datatRepository.GetByIdAsync(id);

            if (localisation == null || localisation.Value == null)
            {
                return NotFound();
            }

            return localisation;
        }


      

        // PUT: api/Localisations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ActionName("Put")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutLocalisation(int id, Localisation localisation)
        {
            if (id != localisation.IdLocalisation)
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
                await datatRepository.UpdateAsync(userToUpdate.Value, localisation);
                return NoContent();
            }

        }

        // POST: api/Localisations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ActionName("Post")]
        public async Task<ActionResult<Localisation>> PostLocalisation(Localisation localisation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await datatRepository.AddAsync(localisation);
            

            return CreatedAtAction("GetById", new { id = localisation.IdLocalisation }, localisation);
        }

        // DELETE: api/Localisations/5
        [HttpDelete("{id}")]
        [ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLocalisation(int id)
        {
            var localisation =  await datatRepository.GetByIdAsync(id);
            if (localisation == null)
            {
                return NotFound();
            }

           await datatRepository.DeleteAsync(localisation.Value);

            return NoContent();
        }

        /*private bool LocalisationExists(int id)
        {
            return _context.Localisations.Any(e => e.LocalisationId == id);
        }*/
    }
}