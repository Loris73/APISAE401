using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class ComptabiliserManager : IDataRepository<Comptabiliser>
    {
        readonly MedDBContext? medDbContext;

        public ComptabiliserManager() { }

        public ComptabiliserManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Comptabiliser>>> GetAllAsync()
        {
            return await medDbContext.Comptabilisers.ToListAsync();
        }
        public async Task<ActionResult<Comptabiliser>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Comptabiliser>> GetByStringAsync(string intitule)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Comptabiliser entity)
        {
            await medDbContext.Comptabilisers.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Comptabiliser Comptabiliser, Comptabiliser entity)
        {
            medDbContext.Entry(Comptabiliser).State = EntityState.Modified;
            Comptabiliser.IdClub = entity.IdClub;
            Comptabiliser.IdTypeChambre = entity.IdTypeChambre;
            Comptabiliser.TypechambreNavigation = entity.TypechambreNavigation;
            Comptabiliser.NbChambre = entity.NbChambre;
            Comptabiliser.ClubNavigation = entity.ClubNavigation;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Comptabiliser entity)
        {
            medDbContext.Comptabilisers.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}