using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class ClubManager : IDataRepository<Club>
    {
        readonly MedDBContext? medDBContext;
        public ClubManager() { }
        public ClubManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Club>>> GetAllAsync()
        {
            return await medDBContext.Club.ToListAsync();
        }
        public async Task<ActionResult<Club>> GetByIdAsync(int id)
        {
            return await medDBContext.Club.FirstOrDefaultAsync(u => u.IdClub == id);
        }
        public async Task<ActionResult<Club>> GetByStringAsync(string intitule)
        {
            return await medDBContext.Club.FirstOrDefaultAsync(u => u.NomClub.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(Club entity)
        {
            await medDBContext.Club.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Club Club, Club entity)
        {
            medDBContext.Entry(Club).State = EntityState.Modified;
            Club.IdClub = entity.IdClub;
            Club.NomClub = entity.NomClub;
            Club.LatitudeLocalisationClub = entity.LatitudeLocalisationClub;
            Club.LongitudeLocalisationClub = entity.LongitudeLocalisationClub;
            Club.DescriptionClub = entity.DescriptionClub;
            Club.AdresseClub = entity.AdresseClub;
            Club.TelClub = entity.TelClub;
            Club.MailClub = entity.MailClub;

            Club.TarifNavigation = entity.TarifNavigation;
            Club.ReservationNavigation = entity.ReservationNavigation;
            Club.DisposerNavigation = entity.DisposerNavigation;
            Club.RegrouperNavigation = entity.RegrouperNavigation;
            Club.SignalementNavigation = entity.SignalementNavigation;
            Club.ReponseNavigation = entity.ReponseNavigation;
            Club.BarNavigation = entity.BarNavigation;
            Club.RestaurantNavigation = entity.RestaurantNavigation;
            Club.PhotoNavigation = entity.PhotoNavigation;
            Club.ProposerNavigation = entity.ProposerNavigation;
            Club.ApoursouslocNavigation = entity.ApoursouslocNavigation;
            Club.AviNavigation = entity.AviNavigation;
            Club.AppartientNavigation = entity.AppartientNavigation;
            Club.ComptabiliserNavigation = entity.ComptabiliserNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Club Club)
        {
            medDBContext.Club.Remove(Club);
            await medDBContext.SaveChangesAsync();
        }
    }
}
