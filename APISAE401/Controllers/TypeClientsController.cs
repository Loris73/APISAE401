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
    public class TypeClientsController : ControllerBase
    {
        private readonly IDataRepository<TypeClient> dataRepository;

        public TypeClientsController(IDataRepository<TypeClient> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Clients
        [HttpGet]
        [ActionName("GetClients")]
        public async Task<ActionResult<IEnumerable<TypeClient>>> GetTypeClients()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Clients/toto@titi.fr
        [HttpGet]
        [Route("[action]/{intitule}")]
        [ActionName("GetByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeClient>> GetTypeClientByIntitule(string intitule)
        {
            var typeclient = await dataRepository.GetByStringAsync(intitule);

            if (typeclient == null)
            {
                return NotFound();
            }

            if (typeclient.Value == null)
            {
                return NotFound();
            }

            return typeclient;
        }


        // GET: api/Clients/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeClient>> GetTypeClientById(int id)
        {
            var typeclient = await dataRepository.GetByIdAsync(id);

            if (typeclient == null)
            {
                return NotFound();
            }
            if (typeclient.Value == null)
            {
                return NotFound();
            }

            return typeclient;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTypeClient(int id, TypeClient typeclient)
        {
            if (id != typeclient.IdTypeClient)
            {
                return BadRequest();
            }

            var typeclientToUpdate = await dataRepository.GetByIdAsync(id);
            if (typeclientToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(typeclientToUpdate.Value, typeclient);
                return NoContent();
            }
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypeClient>> PostClient(TypeClient typeclient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(typeclient);

            return CreatedAtAction("GetById", new { id = typeclient.IdTypeClient }, typeclient); // GetById : nom de l’action
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTypeClient(int id)
        {
            var typeclient = await dataRepository.GetByIdAsync(id);

            if (typeclient == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(typeclient.Value);

            return NoContent();
        }
    }
}