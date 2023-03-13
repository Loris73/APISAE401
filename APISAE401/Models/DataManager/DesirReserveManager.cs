using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class DesireReserveManager : IDataRepository<DesirReserve>
    {
        readonly MedDBContext? medDbContext;

        public DesireReserveManager() { }

        public DesireReserveManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<DesirReserve>>> GetAllAsync()
        {
            return await medDbContext.DesirReserves.ToListAsync();
        }
        public async Task<ActionResult<DesirReserve>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<DesirReserve>> GetByStringAsync(string intitule)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(DesirReserve entity)
        {
            await medDbContext.DesirReserves.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(DesirReserve DesireReserve, DesirReserve entity)
        {
            medDbContext.Entry(DesireReserve).State = EntityState.Modified;
            DesireReserve.IdReservation = entity.IdReservation;
            DesireReserve.IdTypeChambre = entity.IdTypeChambre;
            DesireReserve.ReservationNavigation = entity.ReservationNavigation;
            DesireReserve.TypechambreNavigation = entity.TypechambreNavigation;
            DesireReserve.NbParticipants = entity.NbParticipants;

                        await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(DesirReserve entity)
        {
            medDbContext.DesirReserves.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}