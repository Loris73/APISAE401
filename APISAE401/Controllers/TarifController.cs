using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISAE401.Models.DataManager;
using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APISAE401.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TarifsController : ControllerBase
    {
        
        private readonly IDataRepository<Tarif> datatRepository;

        public TarifsController(IDataRepository<Tarif> dataRepo)
        {
            datatRepository = dataRepo;
        }

        // GET: api/Tarifs
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Tarif>>> GetTarifs()
        {
            return await datatRepository.GetAllAsync();
        }

    }
}