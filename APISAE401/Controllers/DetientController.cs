using APISAE401.Models.DataManager;
using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APISAE401.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class DetientController : ControllerBase
    {
        private readonly IDataRepository<Detient> dataRepository;

        public DetientController(IDataRepository<Detient> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Detients
        [HttpGet]
        [ActionName("GetDetient")]
        public async Task<ActionResult<IEnumerable<Detient>>> GetDetients()
        {
            return await dataRepository.GetAllAsync();
        }

       
    }
}