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
    public class DeplacerController : ControllerBase
    {
        
        private readonly IDataRepository<Deplacer> dataRepository;

        public DeplacerController(IDataRepository<Deplacer> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Deplacers
        [HttpGet]
        [ActionName("GetDeplacers")]
        public async Task<ActionResult<IEnumerable<Deplacer>>> GetDeplacers()
        {
            return await dataRepository.GetAllAsync();
        }
    }
}