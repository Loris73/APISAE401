using APISAE401.Models.DataManager;
using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APISAE401.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class DomaineSkiablesController : ControllerBase
    {
        private readonly IDataRepository<DomaineSkiable> dataRepository;

        public DomaineSkiablesController(IDataRepository<DomaineSkiable> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/DomaineSkiables
        [HttpGet]
        [ActionName("GetDomaineSkiables")]
        public async Task<ActionResult<IEnumerable<DomaineSkiable>>> GetDomaineSkiables()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/DomaineSkiables/lololamoto
        [HttpGet]
        [Route("[action]/{nom}")]
        [ActionName("GetByNom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DomaineSkiable>> GetDomaineSkiableByName(string nom)
        {
            var domaineSkiable = await dataRepository.GetByStringAsync(nom);

            if (domaineSkiable == null)
            {
                return NotFound();
            }

            if (domaineSkiable.Value == null)
            {
                return NotFound();
            }

            return domaineSkiable;
        }


        // GET: api/DomaineSkiables/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DomaineSkiable>> GetDomaineSkiableById(int id)
        {
            var domaineSkiable = await dataRepository.GetByIdAsync(id);

            if (domaineSkiable == null)
            {
                return NotFound();
            }
            if (domaineSkiable.Value == null)
            {
                return NotFound();
            }

            return domaineSkiable;
        }

        // PUT: api/DomaineSkiables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutDomaineSkiable(int id, DomaineSkiable domaineSkiable)
        {
            if (id != domaineSkiable.IdDomaineSkiable)
            {
                return BadRequest();
            }

            var domaineSkiableToUpdate = await dataRepository.GetByIdAsync(id);
            if (domaineSkiableToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(domaineSkiableToUpdate.Value, domaineSkiable);
                return NoContent();
            }
        }

        // POST: api/DomaineSkiables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DomaineSkiable>> PostDomaineSkiable(DomaineSkiable domaineSkiable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(domaineSkiable);

            return CreatedAtAction("GetById", new { id = domaineSkiable.IdDomaineSkiable }, domaineSkiable); // GetById : nom de l’action
        }

        // DELETE: api/DomaineSkiables/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDomaineSkiable(int id)
        {
            var domaineSkiable = await dataRepository.GetByIdAsync(id);

            if (domaineSkiable == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(domaineSkiable.Value);

            return NoContent();
        }
    }
}