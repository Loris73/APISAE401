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
    public class RegroupementsController : ControllerBase
    {
        
        private readonly IDataRepository<Regroupement> datatRepository;

        public RegroupementsController(IDataRepository<Regroupement> dataRepo)
        {
            datatRepository = dataRepo;
        }

        // GET: api/Regroupements
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Regroupement>>> GetRegroupements()
        {
            return await datatRepository.GetAllAsync();
        }

        // GET: api/Regroupements/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Regroupement>> GetRegroupementById(int id)
        {
            var regroupement = await datatRepository.GetByIdAsync(id);

            if (regroupement == null || regroupement.Value == null)
            {
                return NotFound();
            }

            return regroupement;
        }


      

        // PUT: api/Regroupements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ActionName("Put")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutRegroupement(int id, Regroupement regroupement)
        {
            if (id != regroupement.RegroupementId)
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
                await datatRepository.UpdateAsync(userToUpdate.Value, regroupement);
                return NoContent();
            }

        }

        // POST: api/Regroupements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ActionName("Post")]
        public async Task<ActionResult<Regroupement>> PostRegroupement(Regroupement regroupement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await datatRepository.AddAsync(regroupement);
            

            return CreatedAtAction("GetById", new { id = regroupement.RegroupementId }, regroupement);
        }

        // DELETE: api/Regroupements/5
        [HttpDelete("{id}")]
        [ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRegroupement(int id)
        {
            var regroupement =  await datatRepository.GetByIdAsync(id);
            if (regroupement == null)
            {
                return NotFound();
            }

           await datatRepository.DeleteAsync(regroupement.Value);

            return NoContent();
        }

        /*private bool RegroupementExists(int id)
        {
            return _context.Regroupements.Any(e => e.RegroupementId == id);
        }*/
    }
}