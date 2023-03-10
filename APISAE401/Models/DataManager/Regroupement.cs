using API_Film.Models.EntityFramework;
using API_Film.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class RegroupementManager : IDataRepository<Regroupement>
    {
        readonly FilmRatingContext? medDbContext;

        public RegroupementManager() { }

        public RegroupementManager(FilmRatingContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Regroupement>>> GetAll()
        {
            return await medDbContext.Regroupements.ToListAsync();
        }
        public async Task<ActionResult<Regroupement>> GetByIdAsync(int id)
        {
            return await medDbContext.Regroupements.FirstOrDefaultAsync(u => u.IdRegroupement == id);
        }
        
        public async Task AddAsync(Regroupement entity)
        {
            await medDbContext.Regroupements.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Regroupement regroupement, Regroupement entity)
        {
            medDbContext.Entry(regroupement).State = EntityState.Modified;
            regroupement.RegroupementId = entity.RegroupementId;
            regroupement.RegroupementNom = entity.RegroupementNom;
            regroupement.RegrouperNavigation = entity.RegrouperNavigation;

            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Regroupement entity)
        {
            medDbContext.Regroupements.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}