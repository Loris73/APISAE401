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
    public class ClubsController : ControllerBase
    {
        private readonly IDataRepository<Club> dataRepository;

        public ClubsController(IDataRepository<Club> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Clubs
        [HttpGet]
        [ActionName("GetClubs")]
        public async Task<ActionResult<IEnumerable<Club>>> GetClubs()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Clubs/La Rosière
        [HttpGet]
        [Route("[action]/{nom}")]
        [ActionName("GetByNom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Club>> GetClubByName(string nom)
        {
            var club = await dataRepository.GetByStringAsync(nom);

            if (club == null)
            {
                return NotFound();
            }

            if (club.Value == null)
            {
                return NotFound();
            }

            return club;
        }


        // GET: api/Clubs/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Club>> GetClubById(int id)
        {
            var club = await dataRepository.GetByIdAsync(id);

            if (club == null)
            {
                return NotFound();
            }
            if (club.Value == null)
            {
                return NotFound();
            }

            return club;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutClub(int id, Club club)
        {
            if (id != club.IdClub)
            {
                return BadRequest();
            }

            var clubToUpdate = await dataRepository.GetByIdAsync(id);
            if (clubToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(clubToUpdate.Value, club);
                return NoContent();
            }
        }

        // POST: api/Clubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Club>> PostClub(Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(club);

            return CreatedAtAction("GetById", new { id = club.IdClub }, club); // GetById : nom de l’action
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var club = await dataRepository.GetByIdAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(club.Value);

            return NoContent();
        }
    }
}