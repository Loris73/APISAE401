using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class LocalisationManager : IDataRepository<Localisation>
    {
        readonly MedDBContext? medDbContext;

        public LocalisationManager() { }

        public LocalisationManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Localisation>>> GetAllAsync()
        {
            return await medDbContext.Localisations.ToListAsync();
        }
        public async Task<ActionResult<Localisation>> GetByIdAsync(int id)
        {
            return await medDbContext.Localisations.FirstOrDefaultAsync(u => u.IdLocalisation == id);
        }

        public async Task<ActionResult<Localisation>> GetByStringAsync(string intitule)
        {
            return await medDbContext.Localisations.FirstOrDefaultAsync(u => u.LocalisationNom.ToUpper() == intitule.ToUpper());
        }

        public async Task AddAsync(Localisation entity)
        {
            await medDbContext.Localisations.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Localisation localisation, Localisation entity)
        {
            medDbContext.Entry(localisation).State = EntityState.Modified;
            localisation.IdLocalisation = entity.IdLocalisation;
            localisation.LocalisationNom = entity.LocalisationNom;
            localisation.SouslocalisationNavigation = entity.SouslocalisationNavigation;

            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Localisation entity)
        {
            medDbContext.Localisations.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}