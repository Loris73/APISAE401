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
    public class ActiviteController : ControllerBase
    {
        private readonly IDataRepository<Activite> dataRepository;

        public ActiviteController(IDataRepository<Activite> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Activites
        [HttpGet]
        [ActionName("GetActivite")]
        public async Task<ActionResult<IEnumerable<Activite>>> GetActivites()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Activites/La Rosière
        [HttpGet]
        [Route("[action]/{titre}")]
        [ActionName("GetByTitre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Activite>> GetActiviteByTitre(string nom)
        {
            var activite = await dataRepository.GetByStringAsync(nom);

            if (activite == null)
            {
                return NotFound();
            }

            if (activite.Value == null)
            {
                return NotFound();
            }

            return activite;
        }


        // GET: api/Activites/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Activite>> GetActiviteById(int id)
        {
            var activite = await dataRepository.GetByIdAsync(id);

            if (activite == null)
            {
                return NotFound();
            }
            if (activite.Value == null)
            {
                return NotFound();
            }

            return activite;
        }

        // PUT: api/Activites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutActivite(int id, Activite activite)
        {
            if (id != activite.IdActivite)
            {
                return BadRequest();
            }

            var activiteToUpdate = await dataRepository.GetByIdAsync(id);
            if (activiteToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(activiteToUpdate.Value, activite);
                return NoContent();
            }
        }

        // POST: api/Activites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Activite>> PostActivite(Activite activite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(activite);

            return CreatedAtAction("GetById", new { id = activite.IdActivite }, activite); // GetById : nom de l’action
        }

        // DELETE: api/Activites/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteActivite(int id)
        {
            var activite = await dataRepository.GetByIdAsync(id);

            if (activite == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(activite.Value);

            return NoContent();
        }
    }
}