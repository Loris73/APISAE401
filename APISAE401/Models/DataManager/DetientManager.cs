using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class DetientManager : IDataRepository<Detient>
    {
        readonly MedDBContext? medDbContext;

        public DetientManager() { }

        public DetientManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Detient>>> GetAllAsync()
        {
            return await medDbContext.Detients.ToListAsync();
        }
        public async Task<ActionResult<Detient>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Detient>> GetByStringAsync(string intitule)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Detient entity)
        {
            await medDbContext.Detients.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Detient Detient, Detient entity)
        {
            medDbContext.Entry(Detient).State = EntityState.Modified;
            Detient.IdClient = entity.IdClient;
            Detient.IdCarteBancaire = entity.IdCarteBancaire;
            Detient.CartebancaireNavigation = entity.CartebancaireNavigation;
            Detient.ClientNavigation = entity.ClientNavigation;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Detient entity)
        {
            medDbContext.Detients.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}