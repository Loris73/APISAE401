using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class TypeSignalementManager : IDataRepository<TypeSignalement>
    {
        readonly MedDBContext? medDBContext;
        public TypeSignalementManager() { }
        public TypeSignalementManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<TypeSignalement>>> GetAllAsync()
        {
            return await medDBContext.TypeSignalements.ToListAsync();
        }
        public async Task<ActionResult<TypeSignalement>> GetByIdAsync(int id)
        {
            return await medDBContext.TypeSignalements.FirstOrDefaultAsync(u => u.IdTypeSignalement == id);
        }
        public async Task<ActionResult<TypeSignalement>> GetByStringAsync(string intitule)
        {
            return await medDBContext.TypeSignalements.FirstOrDefaultAsync(u => u.TitreTypeSignalement.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(TypeSignalement entity)
        {
            await medDBContext.TypeSignalements.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TypeSignalement typeSignalement, TypeSignalement entity)
        {
            medDBContext.Entry(typeSignalement).State = EntityState.Modified;
            typeSignalement.IdTypeSignalement = entity.IdTypeSignalement;
            typeSignalement.TitreTypeSignalement = entity.TitreTypeSignalement;
            typeSignalement.SignalementNavigation = entity.SignalementNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(TypeSignalement typeSignalement)
        {
            medDBContext.TypeSignalements.Remove(typeSignalement);
            await medDBContext.SaveChangesAsync();
        }
    }
}