using API_Film.Models.EntityFramework;
using API_Film.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class APourPFManager : IDataRepository<APourPF>
    {
        readonly FilmRatingContext? medDbContext;

        public APourPFManager() { }

        public APourPFManager(FilmRatingContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<APourPF>>> GetAll()
        {
            return await medDbContext.APourPFs.ToListAsync();
        }
        public async Task<ActionResult<APourPF>> GetByIdAsync(int id)
        {
            return await medDbContext.APourPFs.FirstOrDefaultAsync(u => u.IdAPourPF == id);
        }
        
        public async Task AddAsync(APourPF entity)
        {
            await medDbContext.APourPFs.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(APourPF aPourPF, APourPF entity)
        {
            medDbContext.Entry(aPourPF).State = EntityState.Modified;
            aPourPF.IdTypeChambre = entity.IdTypeChambre;
            aPourPF.IdPointFort = entity.IdPointFort;
            aPourPF.PointfortNaviguation = entity.PointfortNaviguation;
            aPourPF.TypechambreNavigation = entity.TypechambreNavigation;
            

            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(APourPF entity)
        {
            medDbContext.APourPFs.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}