using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class ActiviteALaCarteManager : IDataRepository<ActiviteALaCarte>
    {
        readonly MedDBContext? medDBContext;
        public ActiviteALaCarteManager() { }
        public ActiviteALaCarteManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<ActiviteALaCarte>>> GetAllAsync()
        {
            return await medDBContext.ActivitesALaCarte.ToListAsync();
        }
        public async Task<ActionResult<ActiviteALaCarte>> GetByIdAsync(int id)
        {
            return await medDBContext.ActivitesALaCarte.FirstOrDefaultAsync(u => u.IdActiviteALaCarte == id);
        }
        public async Task<ActionResult<ActiviteALaCarte>> GetByStringAsync(string intitule)
        {
            return await medDBContext.ActivitesALaCarte.FirstOrDefaultAsync(u => u.TitreActivite.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(ActiviteALaCarte entity)
        {
            await medDBContext.ActivitesALaCarte.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(ActiviteALaCarte ActiviteALaCarte, ActiviteALaCarte entity)
        {
            medDBContext.Entry(ActiviteALaCarte).State = EntityState.Modified;
            ActiviteALaCarte.IdActivite = entity.IdActivite;
            ActiviteALaCarte.IdActiviteALaCarte = entity.IdActiviteALaCarte;
            ActiviteALaCarte.IdTrancheAge = entity.IdTrancheAge;
            ActiviteALaCarte.IdTypeActivite = entity.IdTypeActivite;
            ActiviteALaCarte.TitreActivite = entity.TitreActivite;
            ActiviteALaCarte.DureeActivite = entity.DureeActivite;
            ActiviteALaCarte.DescriptionActivite = entity.DescriptionActivite;
            ActiviteALaCarte.AgeMinActivite = entity.AgeMinActivite;
            ActiviteALaCarte.FrequenceActivite = entity.FrequenceActivite;
            ActiviteALaCarte.PrixMinActivite = entity.PrixMinActivite;
            ActiviteALaCarte.ActiviteNavigation = entity.ActiviteNavigation;
            ActiviteALaCarte.PouvoirNavigation = entity.PouvoirNavigation;
            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(ActiviteALaCarte ActiviteALaCarte)
        {
            medDBContext.ActivitesALaCarte.Remove(ActiviteALaCarte);
            await medDBContext.SaveChangesAsync();
        }
    }
}
