using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class ProposerManager : IDataRepository<Proposer>
    {
        readonly MedDBContext? medDbContext;

        public ProposerManager() { }

        public ProposerManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Proposer>>> GetAllAsync()
        {
            return await medDbContext.Proposers.ToListAsync();
        }
        public async Task<ActionResult<Proposer>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Proposer>> GetByStringAsync(string intitule)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Proposer entity)
        {
            await medDbContext.Proposers.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Proposer Proposer, Proposer entity)
        {
            medDbContext.Entry(Proposer).State = EntityState.Modified;
            Proposer.IdClub = entity.IdClub;
            Proposer.IdActivite = entity.IdActivite;
            Proposer.ActiviteNavigation = entity.ActiviteNavigation;
            Proposer.ClubNavigation = entity.ClubNavigation;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Proposer entity)
        {
            medDbContext.Proposers.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}