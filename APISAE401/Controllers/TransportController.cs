using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APISAE401.Models.EntityFramework;
using NuGet.Versioning;
using APISAE401.Models.DataManager;
using APISAE401.Models.Repository;

namespace APISAE401.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransportsController : ControllerBase
    {
        
        private readonly IDataRepository<Transport> datatRepository;

        public TransportsController(IDataRepository<Transport> dataRepo)
        {
            datatRepository = dataRepo;
        }

        // GET: api/Transports
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Transport>>> GetTransports()
        {
            return await datatRepository.GetAllAsync();
        }

        // GET: api/Transports/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Transport>> GetTransportById(int id)
        {
            var transport = await datatRepository.GetByIdAsync(id);

            if (transport == null || transport.Value == null)
            {
                return NotFound();
            }

            return transport;
        }


      

        // PUT: api/Transports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ActionName("Put")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTransport(int id, Transport transport)
        {
            if (id != transport.IdTransport)
            {
                return BadRequest();
            }

            var userToUpdate = await datatRepository.GetByIdAsync(id);
            if(userToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await datatRepository.UpdateAsync(userToUpdate.Value, transport);
                return NoContent();
            }

        }

        // POST: api/Transports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ActionName("Post")]
        public async Task<ActionResult<Transport>> PostTransport(Transport transport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await datatRepository.AddAsync(transport);
            

            return CreatedAtAction("GetById", new { id = transport.IdTransport }, transport);
        }

        // DELETE: api/Transports/5
        [HttpDelete("{id}")]
        [ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTransport(int id)
        {
            var transport =  await datatRepository.GetByIdAsync(id);
            if (transport == null)
            {
                return NotFound();
            }

           await datatRepository.DeleteAsync(transport.Value);

            return NoContent();
        }

        /*private bool TransportExists(int id)
        {
            return _context.Transports.Any(e => e.TransportId == id);
        }*/
    }
}