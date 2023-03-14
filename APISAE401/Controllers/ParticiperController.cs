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
    public class ParticiperController : ControllerBase
    {
        
        private readonly IDataRepository<Participer> dataRepository;

        public ParticiperController(IDataRepository<Participer> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Participers
        [HttpGet]
        [ActionName("GetParticipers")]
        public async Task<ActionResult<IEnumerable<Participer>>> GetParticipers()
        {
            return await dataRepository.GetAllAsync();
        }
    }
}