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
    public class RegrouperController : ControllerBase
    {
        
        private readonly IDataRepository<Regrouper> dataRepository;

        public RegrouperController(IDataRepository<Regrouper> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Regroupers
        [HttpGet]
        [ActionName("GetRegroupers")]
        public async Task<ActionResult<IEnumerable<Regrouper>>> GetRegroupers()
        {
            return await dataRepository.GetAllAsync();
        }
    }
}