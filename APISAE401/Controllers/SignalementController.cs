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
    public class SignalementController : ControllerBase
    {
        private readonly IDataRepository<Signalement> dataRepository;

        public SignalementController(IDataRepository<Signalement> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Signalements
        [HttpGet]
        [ActionName("GetSignalement")]
        public async Task<ActionResult<IEnumerable<Signalement>>> GetSignalements()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Signalements/La Rosière
        [HttpGet]
        [Route("[action]/{titre}")]
        [ActionName("GetByTitre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Signalement>> GetSignalementByTitre(string nom)
        {
            var signalement = await dataRepository.GetByStringAsync(nom);

            if (signalement == null)
            {
                return NotFound();
            }

            if (signalement.Value == null)
            {
                return NotFound();
            }

            return signalement;
        }


        // GET: api/Signalements/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Signalement>> GetSignalementById(int id)
        {
            var signalement = await dataRepository.GetByIdAsync(id);

            if (signalement == null)
            {
                return NotFound();
            }
            if (signalement.Value == null)
            {
                return NotFound();
            }

            return signalement;
        }

        // PUT: api/Signalements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutSignalement(int id, Signalement signalement)
        {
            if (id != signalement.IdSignalement)
            {
                return BadRequest();
            }

            var signalementToUpdate = await dataRepository.GetByIdAsync(id);
            if (signalementToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(signalementToUpdate.Value, signalement);
                return NoContent();
            }
        }

        // POST: api/Signalements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Signalement>> PostSignalement(Signalement signalement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(signalement);

            return CreatedAtAction("GetById", new { id = signalement.IdSignalement }, signalement); // GetById : nom de l’action
        }

        // DELETE: api/Signalements/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSignalement(int id)
        {
            var signalement = await dataRepository.GetByIdAsync(id);

            if (signalement == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(signalement.Value);

            return NoContent();
        }
    }
}