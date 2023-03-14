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
    public class ActiviteIncluseController : ControllerBase
    {
        private readonly IDataRepository<ActiviteIncluse> dataRepository;

        public ActiviteIncluseController(IDataRepository<ActiviteIncluse> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/ActivitesIncluse
        [HttpGet]
        [ActionName("GetActiviteIncluse")]
        public async Task<ActionResult<IEnumerable<ActiviteIncluse>>> GetActivitesIncluse()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/ActivitesIncluse/La Rosière
        [HttpGet]
        [Route("[action]/{titre}")]
        [ActionName("GetByTitre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ActiviteIncluse>> GetActiviteIncluseByTitre(string nom)
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


        // GET: api/ActivitesIncluse/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ActiviteIncluse>> GetActiviteIncluseById(int id)
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

        // PUT: api/ActivitesIncluse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutActiviteIncluse(int id, ActiviteIncluse activite)
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

        // POST: api/ActivitesIncluse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ActiviteIncluse>> PostActiviteIncluse(ActiviteIncluse activite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(activite);

            return CreatedAtAction("GetById", new { id = activite.IdActivite }, activite); // GetById : nom de l’action
        }

        // DELETE: api/ActivitesIncluse/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteActiviteIncluse(int id)
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