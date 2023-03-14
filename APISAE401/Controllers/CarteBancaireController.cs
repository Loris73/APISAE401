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
    public class CarteBancaireController : ControllerBase
    {
        private readonly IDataRepository<CarteBancaire> dataRepository;

        public CarteBancaireController(IDataRepository<CarteBancaire> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/CarteBancaires
        [HttpGet]
        [ActionName("GetCarteBancaire")]
        public async Task<ActionResult<IEnumerable<CarteBancaire>>> GetCarteBancaires()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/CarteBancaires/La Rosière
        [HttpGet]
        [Route("[action]/{titre}")]
        [ActionName("GetByTitre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CarteBancaire>> GetCarteBancaireByTitre(string nom)
        {
            var carteBancaire = await dataRepository.GetByStringAsync(nom);

            if (carteBancaire == null)
            {
                return NotFound();
            }

            if (carteBancaire.Value == null)
            {
                return NotFound();
            }

            return carteBancaire;
        }


        // GET: api/CarteBancaires/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CarteBancaire>> GetCarteBancaireById(int id)
        {
            var carteBancaire = await dataRepository.GetByIdAsync(id);

            if (carteBancaire == null)
            {
                return NotFound();
            }
            if (carteBancaire.Value == null)
            {
                return NotFound();
            }

            return carteBancaire;
        }

        // PUT: api/CarteBancaires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCarteBancaire(int id, CarteBancaire carteBancaire)
        {
            if (id != carteBancaire.IdCarteBancaire)
            {
                return BadRequest();
            }

            var carteBancaireToUpdate = await dataRepository.GetByIdAsync(id);
            if (carteBancaireToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(carteBancaireToUpdate.Value, carteBancaire);
                return NoContent();
            }
        }

        // POST: api/CarteBancaires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CarteBancaire>> PostCarteBancaire(CarteBancaire carteBancaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(carteBancaire);

            return CreatedAtAction("GetById", new { id = carteBancaire.IdCarteBancaire }, carteBancaire); // GetById : nom de l’action
        }

        // DELETE: api/CarteBancaires/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCarteBancaire(int id)
        {
            var carteBancaire = await dataRepository.GetByIdAsync(id);

            if (carteBancaire == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(carteBancaire.Value);

            return NoContent();
        }
    }
}