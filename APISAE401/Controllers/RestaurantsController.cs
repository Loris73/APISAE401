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
    public class RestaurantsController : ControllerBase
    {
        private readonly IDataRepository<Restaurant> dataRepository;

        public RestaurantsController(IDataRepository<Restaurant> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Restaurants
        [HttpGet]
        [ActionName("GetRestaurants")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Restaurants/5
        [HttpGet]
        [Route("[action]/{idclub}")]
        [ActionName("GetByIdClub")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Restaurant>> GetRestaurantByIdClub(string idClub)
        {
            var restaurant = await dataRepository.GetByStringAsync(idClub);

            if (restaurant == null)
            {
                return NotFound();
            }

            if (restaurant.Value == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        // GET: api/Restaurants/nomRestaurant
        [HttpGet]
        [Route("[action]/{nom}")]
        [ActionName("GetByNom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Restaurant>> GetRestaurantByLogin(string nom)
        {
            var restaurant = await dataRepository.GetByStringAsync(nom);

            if (restaurant == null)
            {
                return NotFound();
            }

            if (restaurant.Value == null)
            {
                return NotFound();
            }

            return restaurant;
        }


        // GET: api/Restaurants/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Restaurant>> GetRestaurantById(int id)
        {
            var restaurant = await dataRepository.GetByIdAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }
            if (restaurant.Value == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        // PUT: api/Restaurants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.IdRestaurant)
            {
                return BadRequest();
            }

            var restaurantToUpdate = await dataRepository.GetByIdAsync(id);
            if (restaurantToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(restaurantToUpdate.Value, restaurant);
                return NoContent();
            }
        }

        // POST: api/Restaurants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(restaurant);

            return CreatedAtAction("GetById", new { id = restaurant.IdRestaurant }, restaurant); // GetById : nom de l’action
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await dataRepository.GetByIdAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(restaurant.Value);

            return NoContent();
        }
    }
}