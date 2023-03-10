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
    public class APourPfsController : ControllerBase
    {
        
        private readonly IDataRepository<APourPf> dataRepository;

        public APourPfsController(IDataRepository<APourPf> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/APourPfs
        [HttpGet]
        [ActionName("GetAPourPfs")]
        public async Task<ActionResult<IEnumerable<APourPf>>> GetAPourPfs()
        {
            return await dataRepository.GetAllAsync();
        }
    }
}