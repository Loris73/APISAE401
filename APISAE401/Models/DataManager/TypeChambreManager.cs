using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class TypeChambreManager : IDataRepository<TypeChambre>
    {
        readonly MedDBContext? medDbContext;

        public TypeChambreManager() { }

        public TypeChambreManager(MedDBContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<TypeChambre>>> GetAllAsync()
        {
            return await medDbContext.TypeChambres.ToListAsync();
        }
        public async Task<ActionResult<TypeChambre>> GetByIdAsync(int id)
        {
            return await medDbContext.TypeChambres.FirstOrDefaultAsync(u => u.TypeChambreId == id);
        }

        public async Task<ActionResult<TypeChambre>> GetByStringAsync(string intitule)
        {
            return await medDbContext.TypeChambres.FirstOrDefaultAsync(u => u.TypeChambreNom.ToUpper() == intitule.ToUpper());
        }

        public async Task AddAsync(TypeChambre entity)
        {
            await medDbContext.TypeChambres.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TypeChambre typeChambre, TypeChambre entity)
        {
            medDbContext.Entry(typeChambre).State = EntityState.Modified;
            typeChambre.TypeChambreId = entity.TypeChambreId;
            typeChambre.TypeChambreNom = entity.TypeChambreNom;
            typeChambre.TypeChambreDimension = entity.TypeChambreDimension;
            typeChambre.TypeChambreCapacite = entity.TypeChambreCapacite;
            typeChambre.TypeChambreDescription = entity.TypeChambreDescription;

            typeChambre.ApourpfNavigation = entity.ApourpfNavigation;
            typeChambre.AvoircommeNavigation = entity.AvoircommeNavigation;
            typeChambre.ComptabiliserNavigation = entity.ComptabiliserNavigation;
            typeChambre.TarifNavigation = entity.TarifNavigation;
            typeChambre.DesirereserveNavigation = entity.DesirereserveNavigation;
            typeChambre.PhotoNavigation = entity.PhotoNavigation;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(TypeChambre entity)
        {
            medDbContext.TypeChambres.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}