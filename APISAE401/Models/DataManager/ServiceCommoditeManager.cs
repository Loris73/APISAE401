using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class ServiceCommoditeManager : IDataRepository<ServiceCommodite>
    {
        readonly MedDBContext? medDBContext;
        public ServiceCommoditeManager() { }
        public ServiceCommoditeManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<ServiceCommodite>>> GetAllAsync()
        {
            return await medDBContext.ServiceCommodites.ToListAsync();
        }
        public async Task<ActionResult<ServiceCommodite>> GetByIdAsync(int id)
        {
            return await medDBContext.ServiceCommodites.FirstOrDefaultAsync(u => u.IdServiceCommodite == id);
        }
        public async Task<ActionResult<ServiceCommodite>> GetByStringAsync(string intitule)
        {
            return await medDBContext.ServiceCommodites.FirstOrDefaultAsync(u => u.NomServiceCommodite.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(ServiceCommodite entity)
        {
            await medDBContext.ServiceCommodites.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(ServiceCommodite ServiceCommodite, ServiceCommodite entity)
        {
            medDBContext.Entry(ServiceCommodite).State = EntityState.Modified;
            ServiceCommodite.IdServiceCommodite = entity.IdServiceCommodite;
            ServiceCommodite.IdCommodite = entity.IdCommodite;
            ServiceCommodite.NomServiceCommodite = entity.NomServiceCommodite;
            ServiceCommodite.CommoditeNavigation = entity.CommoditeNavigation;
            ServiceCommodite.AvoircommeNavigation = entity.AvoircommeNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(ServiceCommodite ServiceCommodite)
        {
            medDBContext.ServiceCommodites.Remove(ServiceCommodite);
            await medDBContext.SaveChangesAsync();
        }
    }
}
