using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class TypeClubManager : IDataRepository<TypeClub>
    {
        readonly MedDBContext? medDBContext;
        public TypeClubManager() { }
        public TypeClubManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<TypeClub>>> GetAllAsync()
        {
            return await medDBContext.TypeClubs.ToListAsync();
        }
        public async Task<ActionResult<TypeClub>> GetByIdAsync(int id)
        {
            return await medDBContext.TypeClubs.FirstOrDefaultAsync(u => u.IdTypeClub == id);
        }
        public async Task<ActionResult<TypeClub>> GetByStringAsync(string intitule)
        {
            return await medDBContext.TypeClubs.FirstOrDefaultAsync(u => u.NomTypeClub.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(TypeClub entity)
        {
            await medDBContext.TypeClubs.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TypeClub typeClub, TypeClub entity)
        {
            medDBContext.Entry(typeClub).State = EntityState.Modified;
            typeClub.IdTypeClub = entity.IdTypeClub;
            typeClub.NomTypeClub = entity.NomTypeClub;
            typeClub.DisposerNavigation = entity.DisposerNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(TypeClub typeClub)
        {
            medDBContext.TypeClubs.Remove(typeClub);
            await medDBContext.SaveChangesAsync();
        }
    }
}