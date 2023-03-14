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
    public class AppartientController : ControllerBase
    {
        
        private readonly IDataRepository<Appartient> dataRepository;

        public AppartientController(IDataRepository<Appartient> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Appartients
        [HttpGet]
        [ActionName("GetAppartients")]
        public async Task<ActionResult<IEnumerable<Appartient>>> GetAppartients()
        {
            return await dataRepository.GetAllAsync();
        }
    }
}