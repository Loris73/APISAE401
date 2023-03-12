using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class TrancheAgeManager : IDataRepository<TrancheAge>
    {
        readonly MedDBContext? medDBContext;
        public TrancheAgeManager() { }
        public TrancheAgeManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<TrancheAge>>> GetAllAsync()
        {
            return await medDBContext.TrancheAges.ToListAsync();
        }
        public async Task<ActionResult<TrancheAge>> GetByIdAsync(int id)
        {
            return await medDBContext.TrancheAges.FirstOrDefaultAsync(u => u.IdTrancheAge == id);
        }
        public async Task<ActionResult<TrancheAge>> GetByStringAsync(string intitule)
        {
            return await medDBContext.TrancheAges.FirstOrDefaultAsync(u => u.DetailTrancheAge.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(TrancheAge entity)
        {
            await medDBContext.TrancheAges.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TrancheAge TrancheAge, TrancheAge entity)
        {
            medDBContext.Entry(TrancheAge).State = EntityState.Modified;
            TrancheAge.IdTrancheAge = entity.IdTrancheAge;
            TrancheAge.DetailTrancheAge = entity.DetailTrancheAge;
            TrancheAge.ActiviteNavigation = entity.ActiviteNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(TrancheAge TrancheAge)
        {
            medDBContext.TrancheAges.Remove(TrancheAge);
            await medDBContext.SaveChangesAsync();
        }
    }
}
