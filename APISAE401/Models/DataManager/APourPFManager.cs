using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class APourPFManager : IDataRepository<APourPf>
    {
        readonly MedDBContext? medDBContext;

        public APourPFManager() { }

        public APourPFManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<APourPf>>> GetAllAsync()
        {
            return await medDBContext.APourPfs.ToListAsync();
        }
        public async Task<ActionResult<APourPf>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<APourPf>> GetByStringAsync(string intitule)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(APourPf entity)
        {
            await medDBContext.APourPfs.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(APourPf aPourPF, APourPf entity)
        {
            medDBContext.Entry(aPourPF).State = EntityState.Modified;
            aPourPF.IdTypeChambre = entity.IdTypeChambre;
            aPourPF.IdPointFort = entity.IdPointFort;
            aPourPF.PointfortNavigation = entity.PointfortNavigation;
            aPourPF.TypechambreNavigation = entity.TypechambreNavigation;
            

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(APourPf entity)
        {
            medDBContext.APourPfs.Remove(entity);
            await medDBContext.SaveChangesAsync();
        }
    }
}