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
    public class CommoditeController : ControllerBase
    {
        private readonly IDataRepository<Commodite> dataRepository;

        public CommoditeController(IDataRepository<Commodite> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Commodites
        [HttpGet]
        [ActionName("GetCommodite")]
        public async Task<ActionResult<IEnumerable<Commodite>>> GetCommodites()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Commodites/La Rosière
        [HttpGet]
        [Route("[action]/{titre}")]
        [ActionName("GetByTitre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Commodite>> GetCommoditeByTitre(string nom)
        {
            var commodite = await dataRepository.GetByStringAsync(nom);

            if (commodite == null)
            {
                return NotFound();
            }

            if (commodite.Value == null)
            {
                return NotFound();
            }

            return commodite;
        }


        // GET: api/Commodites/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Commodite>> GetCommoditeById(int id)
        {
            var commodite = await dataRepository.GetByIdAsync(id);

            if (commodite == null)
            {
                return NotFound();
            }
            if (commodite.Value == null)
            {
                return NotFound();
            }

            return commodite;
        }

        // PUT: api/Commodites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCommodite(int id, Commodite commodite)
        {
            if (id != commodite.IdCommodite)
            {
                return BadRequest();
            }

            var commoditeToUpdate = await dataRepository.GetByIdAsync(id);
            if (commoditeToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(commoditeToUpdate.Value, commodite);
                return NoContent();
            }
        }

        // POST: api/Commodites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Commodite>> PostCommodite(Commodite commodite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(commodite);

            return CreatedAtAction("GetById", new { id = commodite.IdCommodite }, commodite); // GetById : nom de l’action
        }

        // DELETE: api/Commodites/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCommodite(int id)
        {
            var commodite = await dataRepository.GetByIdAsync(id);

            if (commodite == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(commodite.Value);

            return NoContent();
        }
    }
}