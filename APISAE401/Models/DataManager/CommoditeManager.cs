using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class CommoditeManager : IDataRepository<Commodite>
    {
        readonly MedDBContext? medDBContext;
        public CommoditeManager() { }
        public CommoditeManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Commodite>>> GetAllAsync()
        {
            return await medDBContext.Commodites.ToListAsync();
        }
        public async Task<ActionResult<Commodite>> GetByIdAsync(int id)
        {
            return await medDBContext.Commodites.FirstOrDefaultAsync(u => u.IdCommodite == id);
        }
        public async Task<ActionResult<Commodite>> GetByStringAsync(string intitule)
        {
            return await medDBContext.Commodites.FirstOrDefaultAsync(u => u.TypeCommodite.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(Commodite entity)
        {
            await medDBContext.Commodites.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Commodite Commodite, Commodite entity)
        {
            medDBContext.Entry(Commodite).State = EntityState.Modified;
            Commodite.IdCommodite = entity.IdCommodite;
            Commodite.TypeCommodite = entity.TypeCommodite;
            Commodite.ServicecommoditeNavigation = entity.ServicecommoditeNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Commodite Commodite)
        {
            medDBContext.Commodites.Remove(Commodite);
            await medDBContext.SaveChangesAsync();
        }
    }
}

