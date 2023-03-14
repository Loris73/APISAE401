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
    public class APourSousLocController : ControllerBase
    {
        
        private readonly IDataRepository<APourSousLoc> dataRepository;

        public APourSousLocController(IDataRepository<APourSousLoc> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/APourSousLocs
        [HttpGet]
        [ActionName("GetAPourSousLocs")]
        public async Task<ActionResult<IEnumerable<APourSousLoc>>> GetAPourSousLocs()
        {
            return await dataRepository.GetAllAsync();
        }
    }
}