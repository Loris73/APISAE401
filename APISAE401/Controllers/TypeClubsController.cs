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
    public class TypeClubsController : ControllerBase
    {
        private readonly IDataRepository<TypeClub> dataRepository;

        public TypeClubsController(IDataRepository<TypeClub> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Clubs
        [HttpGet]
        [ActionName("GetClubs")]
        public async Task<ActionResult<IEnumerable<TypeClub>>> GetTypeClubs()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Clubs/toto@titi.fr
        [HttpGet]
        [Route("[action]/{intitule}")]
        [ActionName("GetByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeClub>> GetTypeClubByIntitule(string intitule)
        {
            var typeClub = await dataRepository.GetByStringAsync(intitule);

            if (typeClub == null)
            {
                return NotFound();
            }

            if (typeClub.Value == null)
            {
                return NotFound();
            }

            return typeClub;
        }


        // GET: api/Clubs/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeClub>> GetTypeClubById(int id)
        {
            var typeClub = await dataRepository.GetByIdAsync(id);

            if (typeClub == null)
            {
                return NotFound();
            }
            if (typeClub.Value == null)
            {
                return NotFound();
            }

            return typeClub;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTypeClub(int id, TypeClub typeClub)
        {
            if (id != typeClub.IdTypeClub)
            {
                return BadRequest();
            }

            var typeClubToUpdate = await dataRepository.GetByIdAsync(id);
            if (typeClubToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(typeClubToUpdate.Value, typeClub);
                return NoContent();
            }
        }

        // POST: api/Clubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypeClub>> PostClub(TypeClub typeClub)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(typeClub);

            return CreatedAtAction("GetById", new { id = typeClub.IdTypeClub }, typeClub); // GetById : nom de l’action
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTypeClub(int id)
        {
            var typeClub = await dataRepository.GetByIdAsync(id);

            if (typeClub == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(typeClub.Value);

            return NoContent();
        }
    }
}