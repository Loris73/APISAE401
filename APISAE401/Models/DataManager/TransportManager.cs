using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class TransportManager : IDataRepository<Transport>
    {
        readonly MedDBContext? medDbContext;

        public TransportManager() { }

        public TransportManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Transport>>> GetAllAsync()
        {
            return await medDbContext.Transports.ToListAsync();
        }
        public async Task<ActionResult<Transport>> GetByIdAsync(int id)
        {
            return await medDbContext.Transports.FirstOrDefaultAsync(u => u.IdTransport == id);
        }

        public async Task<ActionResult<Transport>> GetByStringAsync(string intitule)
        {
            return await medDbContext.Transports.FirstOrDefaultAsync(u => u.TransportNom.ToUpper() == intitule.ToUpper());
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