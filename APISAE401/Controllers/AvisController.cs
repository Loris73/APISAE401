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
    public class AviController : ControllerBase
    {
        private readonly IDataRepository<Avi> dataRepository;

        public AviController(IDataRepository<Avi> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Avis
        [HttpGet]
        [ActionName("GetAvi")]
        public async Task<ActionResult<IEnumerable<Avi>>> GetAvis()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Avis/La Rosière
        [HttpGet]
        [Route("[action]/{titre}")]
        [ActionName("GetByTitre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Avi>> GetAviByTitre(string nom)
        {
            var avi = await dataRepository.GetByStringAsync(nom);

            if (avi == null)
            {
                return NotFound();
            }

            if (avi.Value == null)
            {
                return NotFound();
            }

            return avi;
        }


        // GET: api/Avis/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Avi>> GetAviById(int id)
        {
            var avi = await dataRepository.GetByIdAsync(id);

            if (avi == null)
            {
                return NotFound();
            }
            if (avi.Value == null)
            {
                return NotFound();
            }

            return avi;
        }

        // PUT: api/Avis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAvi(int id, Avi avi)
        {
            if (id != avi.IdAvi)
            {
                return BadRequest();
            }

            var aviToUpdate = await dataRepository.GetByIdAsync(id);
            if (aviToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(aviToUpdate.Value, avi);
                return NoContent();
            }
        }

        // POST: api/Avis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Avi>> PostAvi(Avi avi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(avi);

            return CreatedAtAction("GetById", new { id = avi.IdAvi }, avi); // GetById : nom de l’action
        }

        // DELETE: api/Avis/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAvi(int id)
        {
            var avi = await dataRepository.GetByIdAsync(id);

            if (avi == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(avi.Value);

            return NoContent();
        }
    }
}