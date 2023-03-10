using API_Film.Models.EntityFramework;
using API_Film.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class CalendrierManager : IDataRepository<Calendrier>
    {
        readonly FilmRatingContext? medDbContext;

        public CalendrierManager() { }

        public CalendrierManager(FilmRatingContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Calendrier>>> GetAll()
        {
            return await medDbContext.Calendriers.ToListAsync();
        }
        public async Task<ActionResult<Calendrier>> GetByIdAsync(int id)
        {
            return await medDbContext.Calendriers.FirstOrDefaultAsync(u => u.IdCalendrier == id);
        }
        
        public async Task AddAsync(Calendrier entity)
        {
            await medDbContext.Calendriers.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Calendrier calendrier, Calendrier entity)
        {
            medDbContext.Entry(calendrier).State = EntityState.Modified;
            calendrier.DateCal = entity.DateCal;
            calendrier.TarifNavigation = entity.TarifNavigation;
            calendrier.ReservationNavigation = entity.ReservationNavigation;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Calendrier entity)
        {
            medDbContext.Calendriers.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}