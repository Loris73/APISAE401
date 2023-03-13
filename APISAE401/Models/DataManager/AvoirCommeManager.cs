using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class AvoirCommeManager : IDataRepository<AvoirComme>
    {
        readonly MedDBContext? medDbContext;

        public AvoirCommeManager() { }

        public AvoirCommeManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<AvoirComme>>> GetAllAsync()
        {
            return await medDbContext.AvoirCommes.ToListAsync();
        }
        public async Task<ActionResult<AvoirComme>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<AvoirComme>> GetByStringAsync(string intitule)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(AvoirComme entity)
        {
            await medDbContext.AvoirCommes.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(AvoirComme AvoirComme, AvoirComme entity)
        {
            medDbContext.Entry(AvoirComme).State = EntityState.Modified;
            AvoirComme.IdServiceCommodite = entity.IdServiceCommodite;
            AvoirComme.IdTypeChambre = entity.IdTypeChambre;
            AvoirComme.ServicecommoditeNavigation = entity.ServicecommoditeNavigation;
            AvoirComme.TypechambreNavigation = entity.TypechambreNavigation;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(AvoirComme entity)
        {
            medDbContext.AvoirCommes.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}