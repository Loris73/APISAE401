using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class RegroupementManager : IDataRepository<Regroupement>
    {
        readonly MedDBContext? medDbContext;

        public RegroupementManager() { }

        public RegroupementManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Regroupement>>> GetAllAsync()
        {
            return await medDbContext.Regroupements.ToListAsync();
        }
        public async Task<ActionResult<Regroupement>> GetByIdAsync(int id)
        {
            return await medDbContext.Regroupements.FirstOrDefaultAsync(u => u.RegroupementId == id);
        }

        public async Task<ActionResult<Regroupement>> GetByStringAsync(string intitule)
        {
            return await medDbContext.Regroupements.FirstOrDefaultAsync(u => u.RegroupementNom.ToUpper() == intitule.ToUpper());
        }

        public async Task AddAsync(Regroupement entity)
        {
            await medDbContext.Regroupements.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Regroupement regroupement, Regroupement entity)
        {
            medDbContext.Entry(regroupement).State = EntityState.Modified;
            regroupement.RegroupementId = entity.RegroupementId;
            regroupement.RegroupementNom = entity.RegroupementNom;
            regroupement.RegrouperNavigation = entity.RegrouperNavigation;

            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Regroupement entity)
        {
            medDbContext.Regroupements.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}