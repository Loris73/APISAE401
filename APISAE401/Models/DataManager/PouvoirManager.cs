using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class PouvoirManager : IDataRepository<Pouvoir>
    {
        readonly MedDBContext? medDbContext;

        public PouvoirManager() { }

        public PouvoirManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Pouvoir>>> GetAllAsync()
        {
            return await medDbContext.Pouvoirs.ToListAsync();
        }
        public async Task<ActionResult<Pouvoir>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Pouvoir>> GetByStringAsync(string intitule)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Pouvoir entity)
        {
            await medDbContext.Pouvoirs.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Pouvoir Pouvoir, Pouvoir entity)
        {
            medDbContext.Entry(Pouvoir).State = EntityState.Modified;
            Pouvoir.IdActivite = entity.IdActivite;
            Pouvoir.IdReservation = entity.IdReservation;
            Pouvoir.PrixMin = entity.PrixMin;
            Pouvoir.ReservationNavigation = entity.ReservationNavigation;
            Pouvoir.ActiviteNavigation = entity.ActiviteNavigation;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Pouvoir entity)
        {
            medDbContext.Pouvoirs.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}