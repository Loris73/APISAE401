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
    public class TypeActivitesController : ControllerBase
    {
        private readonly IDataRepository<TypeActivite> dataRepository;

        public TypeActivitesController(IDataRepository<TypeActivite> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Activites
        [HttpGet]
        [ActionName("GetActivites")]
        public async Task<ActionResult<IEnumerable<TypeActivite>>> GetTypeActivites()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Activites/toto@titi.fr
        [HttpGet]
        [Route("[action]/{intitule}")]
        [ActionName("GetByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeActivite>> GetTypeActiviteByIntitule(string intitule)
        {
            var typeActivite = await dataRepository.GetByStringAsync(intitule);

            if (typeActivite == null)
            {
                return NotFound();
            }

            if (typeActivite.Value == null)
            {
                return NotFound();
            }

            return typeActivite;
        }


        // GET: api/Activites/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeActivite>> GetTypeActiviteById(int id)
        {
            var typeActivite = await dataRepository.GetByIdAsync(id);

            if (typeActivite == null)
            {
                return NotFound();
            }
            if (typeActivite.Value == null)
            {
                return NotFound();
            }

            return typeActivite;
        }

        // PUT: api/Activites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTypeActivite(int id, TypeActivite typeActivite)
        {
            if (id != typeActivite.IdTypeActivite)
            {
                return BadRequest();
            }

            var typeActiviteToUpdate = await dataRepository.GetByIdAsync(id);
            if (typeActiviteToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(typeActiviteToUpdate.Value, typeActivite);
                return NoContent();
            }
        }

        // POST: api/Activites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypeActivite>> PostActivite(TypeActivite typeActivite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(typeActivite);

            return CreatedAtAction("GetById", new { id = typeActivite.IdTypeActivite }, typeActivite); // GetById : nom de l’action
        }

        // DELETE: api/Activites/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTypeActivite(int id)
        {
            var typeActivite = await dataRepository.GetByIdAsync(id);

            if (typeActivite == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(typeActivite.Value);

            return NoContent();
        }
    }
}