using API_Film.Models.EntityFramework;
using API_Film.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class TransportManager : IDataRepository<Transport>
    {
        readonly FilmRatingContext? medDbContext;

        public TransportManager() { }

        public TransportManager(FilmRatingContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Transport>>> GetAll()
        {
            return await medDbContext.Transports.ToListAsync();
        }
        public async Task<ActionResult<Transport>> GetByIdAsync(int id)
        {
            return await medDbContext.Transports.FirstOrDefaultAsync(u => u.IdTransport == id);
        }
        
        public async Task AddAsync(Transport entity)
        {
            await medDbContext.Transports.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Transport transport, Transport entity)
        {
            medDbContext.Entry(transport).State = EntityState.Modified;
            transport.IdTransport = entity.IdTransport;
            transport.TransportNom = entity.TransportNom;
            transport.DeplacerNavigation = entity.DeplacerNavigation;

            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Transport entity)
        {
            medDbContext.Transports.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}