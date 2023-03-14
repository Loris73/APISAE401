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

    [Route("api/[controller]/")]
    [ApiController]
    public class PouvoirController : ControllerBase
    {
        
        private readonly IDataRepository<Pouvoir> dataRepository;

        public PouvoirController(IDataRepository<Pouvoir> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Pouvoirs
        [HttpGet]
        [ActionName("GetPouvoirs")]
        public async Task<ActionResult<IEnumerable<Pouvoir>>> GetPouvoirs()
        {
            return await dataRepository.GetAllAsync();
        }
    }
}