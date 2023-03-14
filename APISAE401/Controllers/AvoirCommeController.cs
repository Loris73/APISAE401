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
    public class AvoirCommeController : ControllerBase
    {
        
        private readonly IDataRepository<AvoirComme> dataRepository;

        public AvoirCommeController(IDataRepository<AvoirComme> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/AvoirCommes
        [HttpGet]
        [ActionName("GetAvoirCommes")]
        public async Task<ActionResult<IEnumerable<AvoirComme>>> GetAvoirCommes()
        {
            return await dataRepository.GetAllAsync();
        }
    }
}