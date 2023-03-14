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
    public class PhotoController : ControllerBase
    {
        private readonly IDataRepository<Photo> dataRepository;

        public PhotoController(IDataRepository<Photo> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Photos
        [HttpGet]
        [ActionName("GetPhoto")]
        public async Task<ActionResult<IEnumerable<Photo>>> GetPhotos()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Photos/La Rosière
        [HttpGet]
        [Route("[action]/{titre}")]
        [ActionName("GetByTitre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Photo>> GetPhotoByTitre(string nom)
        {
            var photo = await dataRepository.GetByStringAsync(nom);

            if (photo == null)
            {
                return NotFound();
            }

            if (photo.Value == null)
            {
                return NotFound();
            }

            return photo;
        }


        // GET: api/Photos/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Photo>> GetPhotoById(int id)
        {
            var photo = await dataRepository.GetByIdAsync(id);

            if (photo == null)
            {
                return NotFound();
            }
            if (photo.Value == null)
            {
                return NotFound();
            }

            return photo;
        }

        // PUT: api/Photos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPhoto(int id, Photo photo)
        {
            if (id != photo.IdPhoto)
            {
                return BadRequest();
            }

            var photoToUpdate = await dataRepository.GetByIdAsync(id);
            if (photoToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(photoToUpdate.Value, photo);
                return NoContent();
            }
        }

        // POST: api/Photos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Photo>> PostPhoto(Photo photo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(photo);

            return CreatedAtAction("GetById", new { id = photo.IdPhoto }, photo); // GetById : nom de l’action
        }

        // DELETE: api/Photos/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            var photo = await dataRepository.GetByIdAsync(id);

            if (photo == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(photo.Value);

            return NoContent();
        }
    }
}