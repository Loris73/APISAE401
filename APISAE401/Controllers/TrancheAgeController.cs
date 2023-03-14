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
    public class TrancheAgeController : ControllerBase
    {
        private readonly IDataRepository<TrancheAge> dataRepository;

        public TrancheAgeController(IDataRepository<TrancheAge> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/TrancheAges
        [HttpGet]
        [ActionName("GetTrancheAge")]
        public async Task<ActionResult<IEnumerable<TrancheAge>>> GetTrancheAges()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/TrancheAges/La Rosière
        [HttpGet]
        [Route("[action]/{titre}")]
        [ActionName("GetByTitre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TrancheAge>> GetTrancheAgeByTitre(string nom)
        {
            var trancheAge = await dataRepository.GetByStringAsync(nom);

            if (trancheAge == null)
            {
                return NotFound();
            }

            if (trancheAge.Value == null)
            {
                return NotFound();
            }

            return trancheAge;
        }


        // GET: api/TrancheAges/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TrancheAge>> GetTrancheAgeById(int id)
        {
            var trancheAge = await dataRepository.GetByIdAsync(id);

            if (trancheAge == null)
            {
                return NotFound();
            }
            if (trancheAge.Value == null)
            {
                return NotFound();
            }

            return trancheAge;
        }

        // PUT: api/TrancheAges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTrancheAge(int id, TrancheAge trancheAge)
        {
            if (id != trancheAge.IdTrancheAge)
            {
                return BadRequest();
            }

            var trancheAgeToUpdate = await dataRepository.GetByIdAsync(id);
            if (trancheAgeToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(trancheAgeToUpdate.Value, trancheAge);
                return NoContent();
            }
        }

        // POST: api/TrancheAges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TrancheAge>> PostTrancheAge(TrancheAge trancheAge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(trancheAge);

            return CreatedAtAction("GetById", new { id = trancheAge.IdTrancheAge }, trancheAge); // GetById : nom de l’action
        }

        // DELETE: api/TrancheAges/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTrancheAge(int id)
        {
            var trancheAge = await dataRepository.GetByIdAsync(id);

            if (trancheAge == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(trancheAge.Value);

            return NoContent();
        }
    }
}