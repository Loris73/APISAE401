using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class DisposerManager : IDataRepository<Disposer>
    {
        readonly MedDBContext? medDbContext;

        public DisposerManager() { }

        public DisposerManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Disposer>>> GetAllAsync()
        {
            return await medDbContext.Disposers.ToListAsync();
        }
        public async Task<ActionResult<Disposer>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Disposer>> GetByStringAsync(string intitule)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Disposer entity)
        {
            await medDbContext.Disposers.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Disposer Disposer, Disposer entity)
        {
            medDbContext.Entry(Disposer).State = EntityState.Modified;
            Disposer.IdClub = entity.IdClub;
            Disposer.IdTypeClub = entity.IdTypeClub;
            Disposer.TypeclubNavigation = entity.TypeclubNavigation;
            Disposer.ClubNavigation = entity.ClubNavigation;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Disposer entity)
        {
            medDbContext.Disposers.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}