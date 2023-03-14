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
    public class DisposerController : ControllerBase
    {
        
        private readonly IDataRepository<Disposer> dataRepository;

        public DisposerController(IDataRepository<Disposer> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Disposers
        [HttpGet]
        [ActionName("GetDisposers")]
        public async Task<ActionResult<IEnumerable<Disposer>>> GetDisposers()
        {
            return await dataRepository.GetAllAsync();
        }
    }
}