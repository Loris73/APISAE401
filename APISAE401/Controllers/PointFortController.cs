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
    public class PointFortsController : ControllerBase
    {
        
        private readonly IDataRepository<PointFort> datatRepository;

        public PointFortsController(IDataRepository<PointFort> dataRepo)
        {
            datatRepository = dataRepo;
        }

        // GET: api/PointForts
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<PointFort>>> GetPointForts()
        {
            return await datatRepository.GetAllAsync();
        }

        // GET: api/PointForts/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PointFort>> GetPointFortById(int id)
        {
            var pointFort = await datatRepository.GetByIdAsync(id);

            if (pointFort == null || pointFort.Value == null)
            {
                return NotFound();
            }

            return pointFort;
        }


      

        // PUT: api/PointForts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ActionName("Put")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPointFort(int id, PointFort pointFort)
        {
            if (id != pointFort.IdPointFort)
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
                await datatRepository.UpdateAsync(userToUpdate.Value, pointFort);
                return NoContent();
            }

        }

        // POST: api/PointForts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ActionName("Post")]
        public async Task<ActionResult<PointFort>> PostPointFort(PointFort pointFort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await datatRepository.AddAsync(pointFort);
            

            return CreatedAtAction("GetById", new { id = pointFort.IdPointFort }, pointFort);
        }

        // DELETE: api/PointForts/5
        [HttpDelete("{id}")]
        [ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePointFort(int id)
        {
            var pointFort =  await datatRepository.GetByIdAsync(id);
            if (pointFort == null)
            {
                return NotFound();
            }

           await datatRepository.DeleteAsync(pointFort.Value);

            return NoContent();
        }

        /*private bool PointFortExists(int id)
        {
            return _context.PointForts.Any(e => e.PointFortId == id);
        }*/
    }
}