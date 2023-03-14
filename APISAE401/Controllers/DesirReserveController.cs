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
    public class DesirReserveController : ControllerBase
    {
        
        private readonly IDataRepository<DesirReserve> dataRepository;

        public DesirReserveController(IDataRepository<DesirReserve> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/DesirReserves
        [HttpGet]
        [ActionName("GetDesirReserves")]
        public async Task<ActionResult<IEnumerable<DesirReserve>>> GetDesirReserves()
        {
            return await dataRepository.GetAllAsync();
        }
    }
}