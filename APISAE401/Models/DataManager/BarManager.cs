using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class BarManager : IDataRepository<Bar>
    {
        readonly MedDBContext? medDBContext;
        public BarManager() { }
        public BarManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Bar>>> GetAllAsync()
        {
            return await medDBContext.Bars.ToListAsync();
        }
        public async Task<ActionResult<Bar>> GetByIdAsync(int id)
        {
            return await medDBContext.Bars.FirstOrDefaultAsync(u => u.IdBar == id);
        }
        public async Task<ActionResult<Bar>> GetByStringAsync(string intitule)
        {
            return await medDBContext.Bars.FirstOrDefaultAsync(u => u.NomBar.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(Bar entity)
        {
            await medDBContext.Bars.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Bar Bar, Bar entity)
        {
            medDBContext.Entry(Bar).State = EntityState.Modified;
            Bar.IdBar = entity.IdBar;
            Bar.IdClub = entity.IdClub;
            Bar.NomBar = entity.NomBar;
            Bar.DescriptionBar = entity.DescriptionBar;
            Bar.ClubNavigation = entity.ClubNavigation;
            Bar.PhotoNavigation = entity.PhotoNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Bar Bar)
        {
            medDBContext.Bars.Remove(Bar);
            await medDBContext.SaveChangesAsync();
        }
    }
}
