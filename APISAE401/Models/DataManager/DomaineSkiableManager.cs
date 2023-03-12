using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class DomaineSkiableManager : IDataRepository<DomaineSkiable>
    {
        readonly MedDBContext? medDBContext;
        public DomaineSkiableManager() { }
        public DomaineSkiableManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<DomaineSkiable>>> GetAllAsync()
        {
            return await medDBContext.DomaineSkiables.ToListAsync();
        }
        public async Task<ActionResult<DomaineSkiable>> GetByIdAsync(int id)
        {
            return await medDBContext.DomaineSkiables.FirstOrDefaultAsync(u => u.IdDomaineSkiable == id);
        }
        public async Task<ActionResult<DomaineSkiable>> GetByStringAsync(string intitule)
        {
            return await medDBContext.DomaineSkiables.FirstOrDefaultAsync(u => u.TitreDomaineSkiable.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(DomaineSkiable entity)
        {
            await medDBContext.DomaineSkiables.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(DomaineSkiable DomaineSkiable, DomaineSkiable entity)
        {
            medDBContext.Entry(DomaineSkiable).State = EntityState.Modified;
            DomaineSkiable.IdDomaineSkiable = entity.IdDomaineSkiable;
            DomaineSkiable.TitreDomaineSkiable = entity.TitreDomaineSkiable;
            DomaineSkiable.NomDomaineSkiable = entity.NomDomaineSkiable;
            DomaineSkiable.AltitudeDomaineSkiable = entity.AltitudeDomaineSkiable;
            DomaineSkiable.LongueurPisteDomaineSkiable = entity.LongueurPisteDomaineSkiable;
            DomaineSkiable.NbPistesDomaineSkiable = entity.NbPistesDomaineSkiable;
            DomaineSkiable.DescriptionDomaineSkiable = entity.DescriptionDomaineSkiable;
            DomaineSkiable.PhotoNavigation = entity.PhotoNavigation;
            DomaineSkiable.AppartientNavigation = entity.AppartientNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(DomaineSkiable DomaineSkiable)
        {
            medDBContext.DomaineSkiables.Remove(DomaineSkiable);
            await medDBContext.SaveChangesAsync();
        }
    }
}
