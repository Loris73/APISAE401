using API_Film.Models.EntityFramework;
using API_Film.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class PointFortManager : IDataRepository<PointFort>
    {
        readonly FilmRatingContext? medDbContext;

        public PointFortManager() { }

        public PointFortManager(FilmRatingContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<PointFort>>> GetAll()
        {
            return await medDbContext.PointForts.ToListAsync();
        }
        public async Task<ActionResult<PointFort>> GetByIdAsync(int id)
        {
            return await medDbContext.PointForts.FirstOrDefaultAsync(u => u.IdPointFort == id);
        }
        
        public async Task AddAsync(PointFort entity)
        {
            await medDbContext.PointForts.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(PointFort pointFort, PointFort entity)
        {
            medDbContext.Entry(pointFort).State = EntityState.Modified;
            pointFort.IdPointFort = entity.IdPointFort;
            pointFort.NomPointFort = entity.NomPointFort;
            pointFort.ApourpfNavigation = entity.ApourpfNavigation;

            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(PointFort entity)
        {
            medDbContext.PointForts.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}