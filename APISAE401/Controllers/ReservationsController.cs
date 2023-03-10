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
    public class ReservationsController : ControllerBase
    {
        private readonly IDataRepository<Reservation> dataRepository;

        public ReservationsController(IDataRepository<Reservation> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Reservations
        [HttpGet]
        [ActionName("GetReservations")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Reservations/5
        [HttpGet]
        [Route("[action]/{idClub}")]
        [ActionName("GetByIdClub")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reservation>> GetReservationByIdClub(int idClub)
        {
            var reservation = await dataRepository.GetByIdAsync(idClub);

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
        [Route("[action]/{idClient}")]
        [ActionName("GetByIdClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reservation>> GetReservationByIdClient(int idClient)
        {
            var reservation = await dataRepository.GetByIdAsync(idClient);

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
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reservation>> GetReservationById(int id)
        {
            var reservation = await dataRepository.GetByIdAsync(id);

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

        // PUT: api/Reservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.IdReservation)
            {
                return BadRequest();
            }

            var reservationToUpdate = await dataRepository.GetByIdAsync(id);
            if (reservationToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(reservationToUpdate.Value, reservation);
                return NoContent();
            }
        }

        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(reservation);

            return CreatedAtAction("GetById", new { id = reservation.IdReservation }, reservation); // GetById : nom de l’action
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await dataRepository.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(reservation.Value);

            return NoContent();
        }
    }
}