using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class DeplacerManager : IDataRepository<Deplacer>
    {
        readonly MedDBContext? medDbContext;

        public DeplacerManager() { }

        public DeplacerManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Deplacer>>> GetAllAsync()
        {
            return await medDbContext.Deplacers.ToListAsync();
        }
        public async Task<ActionResult<Deplacer>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Deplacer>> GetByStringAsync(string intitule)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Deplacer entity)
        {
            await medDbContext.Deplacers.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Deplacer Deplacer, Deplacer entity)
        {
            medDbContext.Entry(Deplacer).State = EntityState.Modified;
            Deplacer.IdTransport = entity.IdTransport;
            Deplacer.IdReservation = entity.IdReservation;
            Deplacer.DeplacerLieu = entity.DeplacerLieu;
            Deplacer.DeplacerMontant = entity.DeplacerMontant;
            Deplacer.ReservationNavigation = entity.ReservationNavigation;
            Deplacer.TransportNavigation = entity.TransportNavigation;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Deplacer entity)
        {
            medDbContext.Deplacers.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}