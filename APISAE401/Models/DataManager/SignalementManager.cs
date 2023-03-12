using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class SignalementManager : IDataRepository<Signalement>
    {
        readonly MedDBContext? medDBContext;
        public SignalementManager() { }
        public SignalementManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Signalement>>> GetAllAsync()
        {
            return await medDBContext.Signalements.ToListAsync();
        }
        public async Task<ActionResult<Signalement>> GetByIdAsync(int id)
        {
            return await medDBContext.Signalements.FirstOrDefaultAsync(u => u.IdSignalement == id);
        }
        public async Task<ActionResult<Signalement>> GetByStringAsync(string intitule)
        {
            return await medDBContext.Signalements.FirstOrDefaultAsync(u => u.DescriptionSignalement.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(Signalement entity)
        {
            await medDBContext.Signalements.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Signalement Signalement, Signalement entity)
        {
            medDBContext.Entry(Signalement).State = EntityState.Modified;
            Signalement.IdSignalement = entity.IdSignalement;
            Signalement.IdClient = entity.IdClient;
            Signalement.IdClub = entity.IdClub;
            Signalement.IdAvis = entity.IdAvis;
            Signalement.IdTypeSignalement = entity.IdTypeSignalement;
            Signalement.DescriptionSignalement = entity.DescriptionSignalement;
            Signalement.ClientNavigation = entity.ClientNavigation;
            Signalement.ClubNavigation = entity.ClubNavigation;
            Signalement.AviNavigation = entity.AviNavigation;
            Signalement.TypesignalementNavigation = entity.TypesignalementNavigation;
            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Signalement Signalement)
        {
            medDBContext.Signalements.Remove(Signalement);
            await medDBContext.SaveChangesAsync();
        }
    }
}
