using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class SousLocalisationManager : IDataRepository<SousLocalisation>
    {
        readonly MedDBContext? medDbContext;

        public SousLocalisationManager() { }

        public SousLocalisationManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<SousLocalisation>>> GetAllAsync()
        {
            return await medDbContext.SousLocalisations.ToListAsync();
        }
        public async Task<ActionResult<SousLocalisation>> GetByIdAsync(int id)
        {
            return await medDbContext.SousLocalisations.FirstOrDefaultAsync(u => u.IdSousLocalisation == id);
        }
        public async Task<ActionResult<SousLocalisation>> GetByStringAsync(string intitule)
        {
            return await medDbContext.SousLocalisations.FirstOrDefaultAsync(u => u.NomSousLocalisation.ToUpper() == intitule.ToUpper());
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