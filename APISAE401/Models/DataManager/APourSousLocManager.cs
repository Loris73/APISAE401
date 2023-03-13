using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class APourSousLocManager : IDataRepository<APourSousLoc>
    {
        readonly MedDBContext? medDbContext;

        public APourSousLocManager() { }

        public APourSousLocManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<APourSousLoc>>> GetAllAsync()
        {
            return await medDbContext.APourSousLocs.ToListAsync();
        }
        public async Task<ActionResult<APourSousLoc>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<APourSousLoc>> GetByStringAsync(string intitule)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(APourSousLoc entity)
        {
            await medDbContext.APourSousLocs.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(APourSousLoc APourSousLoc, APourSousLoc entity)
        {
            medDbContext.Entry(APourSousLoc).State = EntityState.Modified;
            APourSousLoc.IdClub = entity.IdClub;
            APourSousLoc.IdSousLocalisation = entity.IdSousLocalisation;
            APourSousLoc.SouslocalisationNavigation = entity.SouslocalisationNavigation;
            APourSousLoc.ClubNavigation = entity.ClubNavigation;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(APourSousLoc entity)
        {
            medDbContext.APourSousLocs.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}