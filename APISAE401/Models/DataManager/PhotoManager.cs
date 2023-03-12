using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class PhotoManager : IDataRepository<Photo>
    {
        readonly MedDBContext? medDBContext;
        public PhotoManager() { }
        public PhotoManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Photo>>> GetAllAsync()
        {
            return await medDBContext.Photos.ToListAsync();
        }
        public async Task<ActionResult<Photo>> GetByIdAsync(int id)
        {
            return await medDBContext.Photos.FirstOrDefaultAsync(u => u.IdPhoto == id);
        }
        public async Task<ActionResult<Photo>> GetByStringAsync(string intitule)
        {
            return await medDBContext.Photos.FirstOrDefaultAsync(u => u.Urlphoto.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(Photo entity)
        {
            await medDBContext.Photos.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Photo Photo, Photo entity)
        {
            medDBContext.Entry(Photo).State = EntityState.Modified;
            Photo.IdPhoto = entity.IdPhoto;
            Photo.IdBar = entity.IdBar;
            Photo.IdTypeActivite = entity.IdTypeActivite;
            Photo.IdRestaurant = entity.IdRestaurant;
            Photo.IdDomaineSkiable = entity.IdDomaineSkiable;
            Photo.IdClub = entity.IdClub;
            Photo.IdTypeChambre = entity.IdTypeChambre;
            Photo.Urlphoto = entity.Urlphoto;

            Photo.BarNavigation = entity.BarNavigation;
            Photo.TypeActiviteNavigation = entity.TypeActiviteNavigation;
            Photo.RestaurantNavigation = entity.RestaurantNavigation;
            Photo.DomaineSkiableNavigation = entity.DomaineSkiableNavigation;
            Photo.ClubNavigation = entity.ClubNavigation;
            Photo.TypeChambreNavigation = entity.TypeChambreNavigation;


            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Photo Photo)
        {
            medDBContext.Photos.Remove(Photo);
            await medDBContext.SaveChangesAsync();
        }
    }
}
