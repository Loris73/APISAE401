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
    public class TypeSignalementsController : ControllerBase
    {
        private readonly IDataRepository<TypeSignalement> dataRepository;

        public TypeSignalementsController(IDataRepository<TypeSignalement> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Signalements
        [HttpGet]
        [ActionName("GetSignalements")]
        public async Task<ActionResult<IEnumerable<TypeSignalement>>> GetTypeSignalements()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Signalements/toto@titi.fr
        [HttpGet]
        [Route("[action]/{intitule}")]
        [ActionName("GetByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeSignalement>> GetTypeSignalementByIntitule(string intitule)
        {
            var typeSignalement = await dataRepository.GetByStringAsync(intitule);

            if (typeSignalement == null)
            {
                return NotFound();
            }

            if (typeSignalement.Value == null)
            {
                return NotFound();
            }

            return typeSignalement;
        }


        // GET: api/Signalements/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeSignalement>> GetTypeSignalementById(int id)
        {
            var typeSignalement = await dataRepository.GetByIdAsync(id);

            if (typeSignalement == null)
            {
                return NotFound();
            }
            if (typeSignalement.Value == null)
            {
                return NotFound();
            }

            return typeSignalement;
        }

        // PUT: api/Signalements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTypeSignalement(int id, TypeSignalement typeSignalement)
        {
            if (id != typeSignalement.IdTypeSignalement)
            {
                return BadRequest();
            }

            var typeSignalementToUpdate = await dataRepository.GetByIdAsync(id);
            if (typeSignalementToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(typeSignalementToUpdate.Value, typeSignalement);
                return NoContent();
            }
        }

        // POST: api/Signalements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypeSignalement>> PostSignalement(TypeSignalement typeSignalement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(typeSignalement);

            return CreatedAtAction("GetById", new { id = typeSignalement.IdTypeSignalement }, typeSignalement); // GetById : nom de l’action
        }

        // DELETE: api/Signalements/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTypeSignalement(int id)
        {
            var typeSignalement = await dataRepository.GetByIdAsync(id);

            if (typeSignalement == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(typeSignalement.Value);

            return NoContent();
        }
    }
}