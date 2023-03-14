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
    public class ComptabiliserController : ControllerBase
    {
        private readonly IDataRepository<Comptabiliser> dataRepository;

        public ComptabiliserController(IDataRepository<Comptabiliser> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Comptabilisers
        [HttpGet]
        [ActionName("GetComptabiliser")]
        public async Task<ActionResult<IEnumerable<Comptabiliser>>> GetComptabilisers()
        {
            return await dataRepository.GetAllAsync();
        }

       
    }
}