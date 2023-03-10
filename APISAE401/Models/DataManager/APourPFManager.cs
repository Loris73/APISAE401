using API_Film.Models.EntityFramework;
using API_Film.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class APourPFManager : IDataRepository<APourPF>
    {
        readonly FilmRatingContext? filmsDbContext;

        public APourPFManager() { }

        public APourPFManager(FilmRatingContext context)
        {
            filmsDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<APourPF>>> GetAll()
        {
            return await filmsDbContext.APourPFs.ToListAsync();
        }
        public async Task<ActionResult<APourPF>> GetByIdAsync(int id)
        {
            return await filmsDbContext.APourPFs.FirstOrDefaultAsync(u => u.IdAPourPF == id);
        }
        
        public async Task AddAsync(APourPF entity)
        {
            await filmsDbContext.APourPFs.AddAsync(entity);
            await filmsDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(APourPF aPourPF, APourPF entity)
        {
            filmsDbContext.Entry(aPourPF).State = EntityState.Modified;
            aPourPF.IdTypeChambre = entity.IdTypeChambre;
            aPourPF.IdPointFort = entity.IdPointFort;
            

            await filmsDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(APourPF entity)
        {
            filmsDbContext.APourPFs.Remove(entity);
            await filmsDbContext.SaveChangesAsync();
        }
    }
}