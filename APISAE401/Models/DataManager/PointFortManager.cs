using API_Film.Models.EntityFramework;
using API_Film.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class PointFortManager : IDataRepository<PointFort>
    {
        readonly FilmRatingContext? filmsDbContext;

        public PointFortManager() { }

        public PointFortManager(FilmRatingContext context)
        {
            filmsDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<PointFort>>> GetAll()
        {
            return await filmsDbContext.PointForts.ToListAsync();
        }
        public async Task<ActionResult<PointFort>> GetByIdAsync(int id)
        {
            return await filmsDbContext.PointForts.FirstOrDefaultAsync(u => u.IdPointFort == id);
        }
        
        public async Task AddAsync(PointFort entity)
        {
            await filmsDbContext.PointForts.AddAsync(entity);
            await filmsDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(PointFort pointFort, PointFort entity)
        {
            filmsDbContext.Entry(pointFort).State = EntityState.Modified;
            pointFort.IdPointFort = entity.IdPointFort;
            pointFort.NomPointFort = entity.Nom;
            pointFort.ApourpfNavigation = entity.ApourpfNavigation;

            await filmsDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(PointFort entity)
        {
            filmsDbContext.PointForts.Remove(entity);
            await filmsDbContext.SaveChangesAsync();
        }
    }
}