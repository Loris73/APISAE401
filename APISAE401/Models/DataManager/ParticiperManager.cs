using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class ParticiperManager : IDataRepository<Participer>
    {
        readonly MedDBContext? medDbContext;

        public ParticiperManager() { }

        public ParticiperManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Participer>>> GetAllAsync()
        {
            return await medDbContext.Participers.ToListAsync();
        }
        public async Task<ActionResult<Participer>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Participer>> GetByStringAsync(string intitule)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Participer entity)
        {
            await medDbContext.Participers.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Participer Participer, Participer entity)
        {
            medDbContext.Entry(Participer).State = EntityState.Modified;
            Participer.IdParticipant = entity.IdParticipant;
            Participer.IdReservation = entity.IdReservation;
            Participer.ParticipantNavigation = entity.ParticipantNavigation;
            Participer.ReservationNavigation = entity.ReservationNavigation;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Participer entity)
        {
            medDbContext.Participers.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}