using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Film.Models.EntityFramework;
using NuGet.Versioning;
using API_Film.Models.DataManager;
using API_Film.Models.Repository;

namespace APISAE401.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class APourPFsController : ControllerBase
    {
        
        private readonly IDataRepository<APourPf> datatRepository;

        public APourPFsController(IDataRepository<APourPf> dataRepo)
        {
            datatRepository = dataRepo;
        }

        // GET: api/APourPFs
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<APourPf>>> GetAPourPFs()
        {
            return await datatRepository.GetAll();
        }

       

        // GET: api/Reservations/5
        [HttpGet]
        [Route("[action]/{IdTypeChambre}")]
        [ActionName("GetByIdTypeChambre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reservation>> GetReservationByIdTypeChambre(int IdTypeChambre)
        {
            var reservation = await dataRepository.GetByIdAsync(IdTypeChambre);

            if (reservation == null)
            {
                return NotFound();
            }
            if (reservation.Value == null)
            {
                return NotFound();
            }

            return reservation;
        }

        // GET: api/Reservations/5
        [HttpGet]
        [Route("[action]/{IdPointFort}")]
        [ActionName("GetByIdPointFort")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reservation>> GetReservationByIdTypeChambre(int IdPointFort)
        {
            var reservation = await dataRepository.GetByIdAsync(IdPointFort);

            if (reservation == null)
            {
                return NotFound();
            }
            if (reservation.Value == null)
            {
                return NotFound();
            }

            return reservation;
        }


      

        // PUT: api/APourPFs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ActionName("Put")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAPourPF(int id, APourPF aPourPF)
        {
            if (id != aPourPF.APourPFId)
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
                await datatRepository.UpdateAsync(userToUpdate.Value, aPourPF);
                return NoContent();
            }

        }

        // POST: api/APourPFs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ActionName("Post")]
        public async Task<ActionResult<APourPF>> PostAPourPF(APourPF aPourPF)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await datatRepository.AddAsync(aPourPF);
            

            return CreatedAtAction("GetById", new { id = aPourPF.APourPFId }, aPourPF);
        }

        // DELETE: api/APourPFs/5
        [HttpDelete("{id}")]
        [ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAPourPF(int id)
        {
            var aPourPF =  await datatRepository.GetByIdAsync(id);
            if (aPourPF == null)
            {
                return NotFound();
            }

           await datatRepository.DeleteAsync(aPourPF.Value);

            return NoContent();
        }

        /*private bool APourPFExists(int id)
        {
            return _context.APourPFs.Any(e => e.APourPFId == id);
        }*/
    }
}