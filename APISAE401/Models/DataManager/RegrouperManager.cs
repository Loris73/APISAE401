using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class RegrouperManager : IDataRepository<Regrouper>
    {
        readonly MedDBContext? medDbContext;

        public RegrouperManager() { }

        public RegrouperManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Regrouper>>> GetAllAsync()
        {
            return await medDbContext.Regroupers.ToListAsync();
        }
        public async Task<ActionResult<Regrouper>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Regrouper>> GetByStringAsync(string intitule)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Regrouper entity)
        {
            await medDbContext.Regroupers.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Regrouper Regrouper, Regrouper entity)
        {
            medDbContext.Entry(Regrouper).State = EntityState.Modified;
            Regrouper.IdClub = entity.IdClub;
            Regrouper.RegroupementId = entity.RegroupementId;
            Regrouper.RegroupementNavigation = entity.RegroupementNavigation;
            Regrouper.ClubNavigation = entity.ClubNavigation;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Regrouper entity)
        {
            medDbContext.Regroupers.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}