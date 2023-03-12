using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class TypeActiviteManager : IDataRepository<TypeActivite>
    {
        readonly MedDBContext? medDBContext;
        public TypeActiviteManager() { }
        public TypeActiviteManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<TypeActivite>>> GetAllAsync()
        {
            return await medDBContext.TypeActivites.ToListAsync();
        }
        public async Task<ActionResult<TypeActivite>> GetByIdAsync(int id)
        {
            return await medDBContext.TypeActivites.FirstOrDefaultAsync(u => u.IdTypeActivite == id);
        }
        public async Task<ActionResult<TypeActivite>> GetByStringAsync(string intitule)
        {
            return await medDBContext.TypeActivites.FirstOrDefaultAsync(u => u.NomTypeActivite.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(TypeActivite entity)
        {
            await medDBContext.TypeActivites.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TypeActivite typeActivite, TypeActivite entity)
        {
            medDBContext.Entry(typeActivite).State = EntityState.Modified;
            typeActivite.IdTypeActivite = entity.IdTypeActivite;
            typeActivite.NomTypeActivite = entity.NomTypeActivite;
            typeActivite.DescriptionTypeActivite = entity.DescriptionTypeActivite;
            typeActivite.ActiviteNavigation = entity.ActiviteNavigation;
            typeActivite.PhotoNavigation = entity.PhotoNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(TypeActivite typeActivite)
        {
            medDBContext.TypeActivites.Remove(typeActivite);
            await medDBContext.SaveChangesAsync();
        }
    }
}