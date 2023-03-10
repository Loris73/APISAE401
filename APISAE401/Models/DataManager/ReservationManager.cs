using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class ReservationManager : IDataRepository<Reservation>
    {
        readonly MedDBContext? medDBContext;
        public ReservationManager() { }
        public ReservationManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllAsync()
        {
            return await medDBContext.Reservations.ToListAsync();
        }
        public async Task<ActionResult<Reservation>> GetByIdAsync(int id)
        {
            return await medDBContext.Reservations.FirstOrDefaultAsync(u => u.IdReservation == id);
        }

        public async Task<ActionResult<IEnumerable<Reservation>>> GetByIdClubAsync(int idClub)
        {
            // recherche idclub => Liste de resrvation
            return await medDBContext.Reservations.Where(r => r.IdClub == idClub).ToListAsync();
        }
        public async Task<ActionResult<IEnumerable<Reservation>>> GetByIdClientAsync(int idClient)
        {
            // recherche idclient => Liste de resrvation
            return await medDBContext.Reservations.Where(r => r.IdClient == idClient).ToListAsync();
        }
        public async Task AddAsync(Reservation entity)
        {
            await medDBContext.Reservations.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Reservation reservation, Reservation entity)
        {
            medDBContext.Entry(reservation).State = EntityState.Modified;
            reservation.IdReservation = entity.IdReservation;
            reservation.IdClub = entity.IdClub;
            reservation.IdClient = entity.IdClient;
            reservation.DateDebutCalendrier = entity.DateDebutCalendrier;
            reservation.DateFinCalendrier = entity.DateFinCalendrier;
            reservation.DateReservation = entity.DateReservation;
            reservation.Montant = entity.Montant;
            reservation.ClientNavigation = entity.ClientNavigation;
            reservation.ClubNavigation = entity.ClubNavigation;
            reservation.CalendrierNavigation = entity.CalendrierNavigation;
            reservation.ParticiperNavigation = entity.ParticiperNavigation;
            reservation.DeplacerNavigation = entity.DeplacerNavigation;
            reservation.DesirereserveNavigation = entity.DesirereserveNavigation;
            
            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Reservation reservation)
        {
            medDBContext.Reservations.Remove(reservation);
            await medDBContext.SaveChangesAsync();
        }

        public Task<ActionResult<Reservation>> GetByStringAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}