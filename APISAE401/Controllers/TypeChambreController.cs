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
    public class TypeChambresController : ControllerBase
    {
        private readonly IDataRepository<TypeChambre> dataRepository;

        public TypeChambresController(IDataRepository<TypeChambre> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Chambres
        [HttpGet]
        [ActionName("GetChambres")]
        public async Task<ActionResult<IEnumerable<TypeChambre>>> GetTypeChambres()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Chambres/toto@titi.fr
        [HttpGet]
        [Route("[action]/{intitule}")]
        [ActionName("GetByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeChambre>> GetTypeChambreByIntitule(string intitule)
        {
            var typeChambre = await dataRepository.GetByStringAsync(intitule);

            if (typeChambre == null)
            {
                return NotFound();
            }

            if (typeChambre.Value == null)
            {
                return NotFound();
            }

            return typeChambre;
        }


        // GET: api/Chambres/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeChambre>> GetTypeChambreById(int id)
        {
            var typeChambre = await dataRepository.GetByIdAsync(id);

            if (typeChambre == null)
            {
                return NotFound();
            }
            if (typeChambre.Value == null)
            {
                return NotFound();
            }

            return typeChambre;
        }

        // PUT: api/Chambres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTypeChambre(int id, TypeChambre typeChambre)
        {
            if (id != typeChambre.TypeChambreId)
            {
                return BadRequest();
            }

            var typeChambreToUpdate = await dataRepository.GetByIdAsync(id);
            if (typeChambreToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(typeChambreToUpdate.Value, typeChambre);
                return NoContent();
            }
        }

        // POST: api/Chambres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypeChambre>> PostChambre(TypeChambre typeChambre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(typeChambre);

            return CreatedAtAction("GetById", new { id = typeChambre.TypeChambreId }, typeChambre); // GetById : nom de l???action
        }

        // DELETE: api/Chambres/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTypeChambre(int id)
        {
            var typeChambre = await dataRepository.GetByIdAsync(id);

            if (typeChambre == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(typeChambre.Value);

            return NoContent();
        }
    }
}