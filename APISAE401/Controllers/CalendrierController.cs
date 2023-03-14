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
    public class CalendriersController : ControllerBase
    {
        
        private readonly IDataRepository<Calendrier> datatRepository;

        public CalendriersController(IDataRepository<Calendrier> dataRepo)
        {
            datatRepository = dataRepo;
        }

        // GET: api/Calendriers
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Calendrier>>> GetCalendriers()
        {
            return await datatRepository.GetAllAsync();
        }

        // GET: api/Calendriers/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Calendrier>> GetCalendrierById(int id)
        {
            var calendrier = await datatRepository.GetByIdAsync(id);

            if (calendrier == null || calendrier.Value == null)
            {
                return NotFound();
            }

            return calendrier;
        }


      


        /*private bool CalendrierExists(int id)
        {
            return _context.Calendriers.Any(e => e.CalendrierId == id);
        }*/
    }
}