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
    public class ReponseController : ControllerBase
    {
        private readonly IDataRepository<Reponse> dataRepository;

        public ReponseController(IDataRepository<Reponse> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Reponses
        [HttpGet]
        [ActionName("GetReponse")]
        public async Task<ActionResult<IEnumerable<Reponse>>> GetReponses()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Reponses/La Rosière
        [HttpGet]
        [Route("[action]/{titre}")]
        [ActionName("GetByTitre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reponse>> GetReponseByTitre(string nom)
        {
            var reponse = await dataRepository.GetByStringAsync(nom);

            if (reponse == null)
            {
                return NotFound();
            }

            if (reponse.Value == null)
            {
                return NotFound();
            }

            return reponse;
        }


        // GET: api/Reponses/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reponse>> GetReponseById(int id)
        {
            var reponse = await dataRepository.GetByIdAsync(id);

            if (reponse == null)
            {
                return NotFound();
            }
            if (reponse.Value == null)
            {
                return NotFound();
            }

            return reponse;
        }

        // PUT: api/Reponses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutReponse(int id, Reponse reponse)
        {
            if (id != reponse.IdReponse)
            {
                return BadRequest();
            }

            var reponseToUpdate = await dataRepository.GetByIdAsync(id);
            if (reponseToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(reponseToUpdate.Value, reponse);
                return NoContent();
            }
        }

        // POST: api/Reponses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Reponse>> PostReponse(Reponse reponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(reponse);

            return CreatedAtAction("GetById", new { id = reponse.IdReponse }, reponse); // GetById : nom de l’action
        }

        // DELETE: api/Reponses/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteReponse(int id)
        {
            var reponse = await dataRepository.GetByIdAsync(id);

            if (reponse == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(reponse.Value);

            return NoContent();
        }
    }
}