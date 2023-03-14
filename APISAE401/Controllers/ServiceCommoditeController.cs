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
    public class ServiceCommoditeController : ControllerBase
    {
        private readonly IDataRepository<ServiceCommodite> dataRepository;

        public ServiceCommoditeController(IDataRepository<ServiceCommodite> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/ServiceCommodites
        [HttpGet]
        [ActionName("GetServiceCommodite")]
        public async Task<ActionResult<IEnumerable<ServiceCommodite>>> GetServiceCommodites()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/ServiceCommodites/La Rosière
        [HttpGet]
        [Route("[action]/{titre}")]
        [ActionName("GetByTitre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceCommodite>> GetServiceCommoditeByTitre(string nom)
        {
            var serviceCommodite = await dataRepository.GetByStringAsync(nom);

            if (serviceCommodite == null)
            {
                return NotFound();
            }

            if (serviceCommodite.Value == null)
            {
                return NotFound();
            }

            return serviceCommodite;
        }


        // GET: api/ServiceCommodites/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceCommodite>> GetServiceCommoditeById(int id)
        {
            var serviceCommodite = await dataRepository.GetByIdAsync(id);

            if (serviceCommodite == null)
            {
                return NotFound();
            }
            if (serviceCommodite.Value == null)
            {
                return NotFound();
            }

            return serviceCommodite;
        }

        // PUT: api/ServiceCommodites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutServiceCommodite(int id, ServiceCommodite serviceCommodite)
        {
            if (id != serviceCommodite.IdServiceCommodite)
            {
                return BadRequest();
            }

            var serviceCommoditeToUpdate = await dataRepository.GetByIdAsync(id);
            if (serviceCommoditeToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(serviceCommoditeToUpdate.Value, serviceCommodite);
                return NoContent();
            }
        }

        // POST: api/ServiceCommodites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServiceCommodite>> PostServiceCommodite(ServiceCommodite serviceCommodite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(serviceCommodite);

            return CreatedAtAction("GetById", new { id = serviceCommodite.IdServiceCommodite }, serviceCommodite); // GetById : nom de l’action
        }

        // DELETE: api/ServiceCommodites/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteServiceCommodite(int id)
        {
            var serviceCommodite = await dataRepository.GetByIdAsync(id);

            if (serviceCommodite == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(serviceCommodite.Value);

            return NoContent();
        }
    }
}