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
    public class ParticipantController : ControllerBase
    {
        private readonly IDataRepository<Participant> dataRepository;

        public ParticipantController(IDataRepository<Participant> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Participants
        [HttpGet]
        [ActionName("GetParticipant")]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Participants/La Rosière
        [HttpGet]
        [Route("[action]/{titre}")]
        [ActionName("GetByTitre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Participant>> GetParticipantByTitre(string nom)
        {
            var participant = await dataRepository.GetByStringAsync(nom);

            if (participant == null)
            {
                return NotFound();
            }

            if (participant.Value == null)
            {
                return NotFound();
            }

            return participant;
        }


        // GET: api/Participants/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Participant>> GetParticipantById(int id)
        {
            var participant = await dataRepository.GetByIdAsync(id);

            if (participant == null)
            {
                return NotFound();
            }
            if (participant.Value == null)
            {
                return NotFound();
            }

            return participant;
        }

        // PUT: api/Participants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutParticipant(int id, Participant participant)
        {
            if (id != participant.IdParticipant)
            {
                return BadRequest();
            }

            var participantToUpdate = await dataRepository.GetByIdAsync(id);
            if (participantToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(participantToUpdate.Value, participant);
                return NoContent();
            }
        }

        // POST: api/Participants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Participant>> PostParticipant(Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(participant);

            return CreatedAtAction("GetById", new { id = participant.IdParticipant }, participant); // GetById : nom de l’action
        }

        // DELETE: api/Participants/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var participant = await dataRepository.GetByIdAsync(id);

            if (participant == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(participant.Value);

            return NoContent();
        }
    }
}