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
    public class ProposerController : ControllerBase
    {
        private readonly IDataRepository<Proposer> dataRepository;

        public ProposerController(IDataRepository<Proposer> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Proposers
        [HttpGet]
        [ActionName("GetProposer")]
        public async Task<ActionResult<IEnumerable<Proposer>>> GetProposers()
        {
            return await dataRepository.GetAllAsync();
        }

       
    }
}