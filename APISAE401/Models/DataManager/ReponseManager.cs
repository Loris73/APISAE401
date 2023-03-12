using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class ReponseManager : IDataRepository<Reponse>
    {
        readonly MedDBContext? medDBContext;
        public ReponseManager() { }
        public ReponseManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Reponse>>> GetAllAsync()
        {
            return await medDBContext.Reponses.ToListAsync();
        }
        public async Task<ActionResult<Reponse>> GetByIdAsync(int id)
        {
            return await medDBContext.Reponses.FirstOrDefaultAsync(u => u.IdReponse == id);
        }
        public async Task<ActionResult<Reponse>> GetByStringAsync(string intitule)
        {
            return await medDBContext.Reponses.FirstOrDefaultAsync(u => u.TitreReponse.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(Reponse entity)
        {
            await medDBContext.Reponses.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Reponse Reponse, Reponse entity)
        {
            medDBContext.Entry(Reponse).State = EntityState.Modified;
            Reponse.IdReponse = entity.IdReponse;
            Reponse.IdClient = entity.IdClient;
            Reponse.IdClub = entity.IdClub;
            Reponse.TitreReponse = entity.TitreReponse;
            Reponse.CommentaireReponse = entity.CommentaireReponse;
            Reponse.ClientNavigation = entity.ClientNavigation;
            Reponse.ClubNavigation = entity.ClubNavigation;
            Reponse.AviNavigation = entity.AviNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Reponse Reponse)
        {
            medDBContext.Reponses.Remove(Reponse);
            await medDBContext.SaveChangesAsync();
        }
    }
}
