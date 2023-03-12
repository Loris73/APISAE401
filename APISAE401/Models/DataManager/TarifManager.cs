using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class TarifManager : IDataRepository<Tarif>
    {
        readonly MedDBContext? medDbContext;

        public TarifManager() { }

        public TarifManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Tarif>>> GetAllAsync()
        {
            return await medDbContext.Tarifs.ToListAsync();
        }
        public async Task<ActionResult<Tarif>> GetByIdAsync(int id)
        {
            return await medDbContext.Tarifs.FirstOrDefaultAsync(u => u.IdTypeChambre == id);
        }
        public async Task<ActionResult<Tarif>> GetByStringAsync(string intitule)
        {
            return await medDbContext.Tarifs.FirstOrDefaultAsync(u => u.Prix.ToString() == intitule.ToUpper());
        }

        public async Task AddAsync(Tarif entity)
        {
            await medDbContext.Tarifs.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Tarif tarif, Tarif entity)
        {
            medDbContext.Entry(tarif).State = EntityState.Modified;
            tarif.IdTypeChambre = entity.IdTypeChambre;
            tarif.IdClub = entity.IdClub;
            tarif.DateCal = entity.DateCal;
            tarif.Prix = entity.Prix;
            tarif.TypechambreNavigation = entity.TypechambreNavigation;
            tarif.ClubNavigation = entity.ClubNavigation;
            tarif.CalendrierNavigation = entity.CalendrierNavigation;

            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Tarif entity)
        {
            medDbContext.Tarifs.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}