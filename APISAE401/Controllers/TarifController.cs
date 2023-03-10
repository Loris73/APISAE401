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
    public class TarifsController : ControllerBase
    {
        
        private readonly IDataRepository<Tarif> datatRepository;

        public TarifsController(IDataRepository<Tarif> dataRepo)
        {
            datatRepository = dataRepo;
        }

        // GET: api/Tarifs
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Tarif>>> GetTarifs()
        {
            return await datatRepository.GetAll();
        }

        // GET: api/Tarifs/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Tarif>> GetTarifById(int id)
        {
            var tarif = await datatRepository.GetByIdAsync(id);

            if (tarif == null || tarif.Value == null)
            {
                return NotFound();
            }

            return tarif;
        }


      

        // PUT: api/Tarifs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ActionName("Put")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTarif(int id, Tarif tarif)
        {
            if (id != tarif.TarifId)
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
                await datatRepository.UpdateAsync(userToUpdate.Value, tarif);
                return NoContent();
            }

        }

        // POST: api/Tarifs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ActionName("Post")]
        public async Task<ActionResult<Tarif>> PostTarif(Tarif tarif)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await datatRepository.AddAsync(tarif);
            

            return CreatedAtAction("GetById", new { id = tarif.IdTypeChambre }, tarif);
        }

        // DELETE: api/Tarifs/5
        [HttpDelete("{id}")]
        [ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTarif(int id)
        {
            var tarif =  await datatRepository.GetByIdAsync(id);
            if (tarif == null)
            {
                return NotFound();
            }

           await datatRepository.DeleteAsync(tarif.Value);

            return NoContent();
        }

        /*private bool TarifExists(int id)
        {
            return _context.Tarifs.Any(e => e.TarifId == id);
        }*/
    }
}