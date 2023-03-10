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
    public class TypeChambresController : ControllerBase
    {
        
        private readonly IDataRepository<TypeChambre> datatRepository;

        public TypeChambresController(IDataRepository<TypeChambre> dataRepo)
        {
            datatRepository = dataRepo;
        }

        // GET: api/TypeChambres
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<TypeChambre>>> GetTypeChambres()
        {
            return await datatRepository.GetAll();
        }

        // GET: api/TypeChambres/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeChambre>> GetTypeChambreById(int id)
        {
            var typeChambre = await datatRepository.GetByIdAsync(id);

            if (typeChambre == null || typeChambre.Value == null)
            {
                return NotFound();
            }

            return typeChambre;
        }


      

        // PUT: api/TypeChambres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ActionName("Put")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTypeChambre(int id, TypeChambre typeChambre)
        {
            if (id != typeChambre.TypeChambreId)
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
                await datatRepository.UpdateAsync(userToUpdate.Value, typeChambre);
                return NoContent();
            }

        }

        // POST: api/TypeChambres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ActionName("Post")]
        public async Task<ActionResult<TypeChambre>> PostTypeChambre(TypeChambre typeChambre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await datatRepository.AddAsync(typeChambre);
            

            return CreatedAtAction("GetById", new { id = typeChambre.TypeChambreId }, typeChambre);
        }

        // DELETE: api/TypeChambres/5
        [HttpDelete("{id}")]
        [ActionName("Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTypeChambre(int id)
        {
            var typeChambre =  await datatRepository.GetByIdAsync(id);
            if (typeChambre == null)
            {
                return NotFound();
            }

           await datatRepository.DeleteAsync(typeChambre.Value);

            return NoContent();
        }

        /*private bool TypeChambreExists(int id)
        {
            return _context.TypeChambres.Any(e => e.TypeChambreId == id);
        }*/
    }
}