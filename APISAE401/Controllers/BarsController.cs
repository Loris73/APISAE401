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
    public class BarsController : ControllerBase
    {
        private readonly IDataRepository<Bar> dataRepository;

        public BarsController(IDataRepository<Bar> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Bars
        [HttpGet]
        [ActionName("GetBars")]
        public async Task<ActionResult<IEnumerable<Bar>>> GetBars()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Bars/5
        [HttpGet]
        [Route("[action]/{idclub}")]
        [ActionName("GetByIdClub")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bar>> GetbarByIdClub(string idClub)
        {
            var bar = await dataRepository.GetByStringAsync(idClub);

            if (bar == null)
            {
                return NotFound();
            }

            if (bar.Value == null)
            {
                return NotFound();
            }

            return bar;
        }

        // GET: api/Bars/nomBar
        [HttpGet]
        [Route("[action]/{nom}")]
        [ActionName("GetByNom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bar>> GetbarByLogin(string nom)
        {
            var bar = await dataRepository.GetByStringAsync(nom);

            if (bar == null)
            {
                return NotFound();
            }

            if (bar.Value == null)
            {
                return NotFound();
            }

            return bar;
        }


        // GET: api/Bars/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bar>> GetbarById(int id)
        {
            var bar = await dataRepository.GetByIdAsync(id);

            if (bar == null)
            {
                return NotFound();
            }
            if (bar.Value == null)
            {
                return NotFound();
            }

            return bar;
        }

        // PUT: api/Bars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Putbar(int id, Bar bar)
        {
            if (id != bar.IdBar)
            {
                return BadRequest();
            }

            var barToUpdate = await dataRepository.GetByIdAsync(id);
            if (barToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(barToUpdate.Value, bar);
                return NoContent();
            }
        }

        // POST: api/Bars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Bar>> Postbar(Bar bar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(bar);

            return CreatedAtAction("GetById", new { id = bar.IdBar }, bar); // GetById : nom de l’action
        }

        // DELETE: api/Bars/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deletebar(int id)
        {
            var bar = await dataRepository.GetByIdAsync(id);

            if (bar == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(bar.Value);

            return NoContent();
        }
    }
}