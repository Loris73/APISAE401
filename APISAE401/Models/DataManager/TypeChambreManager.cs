using API_Film.Models.EntityFramework;
using API_Film.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Film.Models.DataManager
{
    public class TypeChambreManager : IDataRepository<TypeChambre>
    {
        readonly FilmRatingContext? medDbContext;

        public TypeChambreManager() { }

        public TypeChambreManager(FilmRatingContext context)
        {
            medDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<TypeChambre>>> GetAll()
        {
            return await medDbContext.TypeChambres.ToListAsync();
        }
        public async Task<ActionResult<TypeChambre>> GetByIdAsync(int id)
        {
            return await medDbContext.TypeChambres.FirstOrDefaultAsync(u => u.TypeChambreId == id);
        }
        
        public async Task AddAsync(TypeChambre entity)
        {
            await medDbContext.TypeChambres.AddAsync(entity);
            await medDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TypeChambre medtypeChambre, TypeChambre entity)
        {
            medDbContext.Entry(medtypeChambre).State = EntityState.Modified;
            typeChambre.TypeChambreId = entity.TypeChambreId;
            typeChambre.TypeChambreNom = entity.TypeChambreNom;
            typeChambre.TypeChambreCapacite = entity.TypeChambreCapacite;
            typeChambre.TypeChambreDescription = entity.TypeChambreDescription;
            typeChambre.ApourpfNavigation = entity.ApourpfNavigation;
            typeChambre.AvoircommeNavigation = entity.AvoircommeNavigation;
            typeChambre.ComptabiliserNavigation = entity.ComptabiliserNavigation;
            typeChambre.TarifNavigation = entity.TarifNavigation;
            typeChambre.DesirereserveNavigation = entity.DesirereserveNavigation;
            typeChambre.PhotoNavigation = entity.TypeChambrePhotoNavigationCapacite;


            await medDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(TypeChambre entity)
        {
            medDbContext.TypeChambres.Remove(entity);
            await medDbContext.SaveChangesAsync();
        }
    }
}