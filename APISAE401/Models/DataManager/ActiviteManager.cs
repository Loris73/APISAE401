using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class ActiviteManager : IDataRepository<Activite>
    {
        readonly MedDBContext? medDBContext;
        public ActiviteManager() { }
        public ActiviteManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Activite>>> GetAllAsync()
        {
            return await medDBContext.Activites.ToListAsync();
        }
        public async Task<ActionResult<Activite>> GetByIdAsync(int id)
        {
            return await medDBContext.Activites.FirstOrDefaultAsync(u => u.IdActivite == id);
        }
        public async Task<ActionResult<Activite>> GetByStringAsync(string intitule)
        {
            return await medDBContext.Activites.FirstOrDefaultAsync(u => u.TitreActivite.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(Activite entity)
        {
            await medDBContext.Activites.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Activite Activite, Activite entity)
        {
            medDBContext.Entry(Activite).State = EntityState.Modified;
            Activite.IdActivite = entity.IdActivite;
            Activite.IdTrancheAge = entity.IdTrancheAge;
            Activite.IdTypeActivite = entity.IdTypeActivite;
            Activite.TitreActivite = entity.TitreActivite;
            Activite.DureeActivite = entity.DureeActivite;
            Activite.DescriptionActivite = entity.DescriptionActivite;
            Activite.AgeMinActivite = entity.AgeMinActivite;
            Activite.FrequenceActivite = entity.FrequenceActivite;
            Activite.TrancheageNavigation = entity.TrancheageNavigation;
            Activite.TypeactiviteNavigation = entity.TypeactiviteNavigation;
            Activite.ActiviteincluseNavigation = entity.ActiviteincluseNavigation;
            Activite.ActivitealacarteNavigation = entity.ActivitealacarteNavigation;
            Activite.ProposerNavigation = entity.ProposerNavigation;
            Activite.PouvoirNavigation = entity.PouvoirNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Activite Activite)
        {
            medDBContext.Activites.Remove(Activite);
            await medDBContext.SaveChangesAsync();
        }
    }
}
