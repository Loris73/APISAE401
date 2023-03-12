using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class ActiviteIncluseManager : IDataRepository<ActiviteIncluse>
    {
        readonly MedDBContext? medDBContext;
        public ActiviteIncluseManager() { }
        public ActiviteIncluseManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<ActiviteIncluse>>> GetAllAsync()
        {
            return await medDBContext.ActivitesIncluses.ToListAsync();
        }
        public async Task<ActionResult<ActiviteIncluse>> GetByIdAsync(int id)
        {
            return await medDBContext.ActivitesIncluses.FirstOrDefaultAsync(u => u.IdActiviteIncluse == id);
        }
        public async Task<ActionResult<ActiviteIncluse>> GetByStringAsync(string intitule)
        {
            return await medDBContext.ActivitesIncluses.FirstOrDefaultAsync(u => u.TitreActivite.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(ActiviteIncluse entity)
        {
            await medDBContext.ActivitesIncluses.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(ActiviteIncluse ActiviteIncluse, ActiviteIncluse entity)
        {
            medDBContext.Entry(ActiviteIncluse).State = EntityState.Modified;
            ActiviteIncluse.IdActivite = entity.IdActivite;
            ActiviteIncluse.IdActiviteIncluse = entity.IdActiviteIncluse;
            ActiviteIncluse.IdTrancheAge = entity.IdTrancheAge;
            ActiviteIncluse.IdTypeActivite = entity.IdTypeActivite;
            ActiviteIncluse.TitreActivite = entity.TitreActivite;
            ActiviteIncluse.DureeActivite = entity.DureeActivite;
            ActiviteIncluse.DescriptionActivite = entity.DescriptionActivite;
            ActiviteIncluse.AgeMinActivite = entity.AgeMinActivite;
            ActiviteIncluse.FrequenceActivite = entity.FrequenceActivite;
            ActiviteIncluse.ActiviteNavigation = entity.ActiviteNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(ActiviteIncluse ActiviteIncluse)
        {
            medDBContext.ActivitesIncluses.Remove(ActiviteIncluse);
            await medDBContext.SaveChangesAsync();
        }
    }
}
