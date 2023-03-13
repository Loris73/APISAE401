using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class AppartientManager : IDataRepository<Appartient>
    {
        readonly MedDBContext? medDbContext;

        public AppartientManager() { }

        public AppartientManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Appartient>>> GetAllAsync()
        {
            return await medDbContext.Appartients.ToListAsync();
        }
        public async Task<ActionResult<Appartient>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Appartient>> GetByStringAsync(string intitule)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Appartient entity)
        {
            await medDbContext.Appartients.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Appartient Appartient, Appartient entity)
        {
            medDbContext.Entry(Appartient).State = EntityState.Modified;
            Appartient.IdClub = entity.IdClub;
            Appartient.IdDommaineSkiable = entity.IdDommaineSkiable;
            Appartient.DomaineskiableNavigation = entity.DomaineskiableNavigation;
            Appartient.ClubNavigation = entity.ClubNavigation;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Appartient entity)
        {
            medDbContext.Appartients.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}