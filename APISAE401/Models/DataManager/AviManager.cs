using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class AviManager : IDataRepository<Avi>
    {
        readonly MedDBContext? medDBContext;
        public AviManager() { }
        public AviManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Avi>>> GetAllAsync()
        {
            return await medDBContext.Avis.ToListAsync();
        }
        public async Task<ActionResult<Avi>> GetByIdAsync(int id)
        {
            return await medDBContext.Avis.FirstOrDefaultAsync(u => u.IdAvi == id);
        }
        public async Task<ActionResult<Avi>> GetByStringAsync(string intitule)
        {
            return await medDBContext.Avis.FirstOrDefaultAsync(u => u.TitreAvi.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(Avi entity)
        {
            await medDBContext.Avis.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Avi Avi, Avi entity)
        {
            medDBContext.Entry(Avi).State = EntityState.Modified;
            Avi.IdAvi = entity.IdAvi;
            Avi.IdClient = entity.IdClient;
            Avi.IdClub = entity.IdClub;
            Avi.TitreAvi = entity.TitreAvi;
            Avi.NoteAvi = entity.NoteAvi;
            Avi.CommentaireAvi = entity.CommentaireAvi;
            Avi.ClientNavigation = entity.ClientNavigation;
            Avi.ClubNavigation = entity.ClubNavigation;
            Avi.ReponseNavigation = entity.ReponseNavigation;
            Avi.SignalementNavigation = entity.SignalementNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Avi Avi)
        {
            medDBContext.Avis.Remove(Avi);
            await medDBContext.SaveChangesAsync();
        }
    }
}
