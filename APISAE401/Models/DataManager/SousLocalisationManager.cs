using API_Film.Models.EntityFramework;
using API_Film.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class SousLocalisationManager : IDataRepository<SousLocalisation>
    {
        readonly FilmRatingContext? medDbContext;

        public SousLocalisationManager() { }

        public SousLocalisationManager(FilmRatingContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<SousLocalisation>>> GetAll()
        {
            return await medDbContext.SousLocalisations.ToListAsync();
        }
        public async Task<ActionResult<SousLocalisation>> GetByIdAsync(int id)
        {
            return await medDbContext.SousLocalisations.FirstOrDefaultAsync(u => u.IdSousLocalisation == id);
        }
        
        public async Task AddAsync(SousLocalisation entity)
        {
            await medDbContext.SousLocalisations.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(SousLocalisation sousLocalisation, SousLocalisation entity)
        {
            medDbContext.Entry(sousLocalisation).State = EntityState.Modified;
            sousLocalisation.IdSousLocalisation = entity.IdSousLocalisation;
            sousLocalisation.IdLocalisation = entity.IdLocalisation;
            sousLocalisation.NomSousLocalisation = entity.NomSousLocalisation;
            sousLocalisation.LocalisationNavigation = entity.LocalisationNavigation;
            sousLocalisation.ApoursouslocNavigation = entity.ApoursouslocNavigation;

            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(SousLocalisation entity)
        {
            medDbContext.SousLocalisations.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}