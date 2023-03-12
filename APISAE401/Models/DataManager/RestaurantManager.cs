using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class RestaurantManager : IDataRepository<Restaurant>
    {
        readonly MedDBContext? medDBContext;
        public RestaurantManager() { }
        public RestaurantManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetAllAsync()
        {
            return await medDBContext.Restaurants.ToListAsync();
        }
        public async Task<ActionResult<Restaurant>> GetByIdAsync(int id)
        {
            return await medDBContext.Restaurants.FirstOrDefaultAsync(u => u.IdRestaurant == id);
        }
        public async Task<ActionResult<Restaurant>> GetByStringAsync(string intitule)
        {
            return await medDBContext.Restaurants.FirstOrDefaultAsync(u => u.NomRestaurant.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(Restaurant entity)
        {
            await medDBContext.Restaurants.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Restaurant Restaurant, Restaurant entity)
        {
            medDBContext.Entry(Restaurant).State = EntityState.Modified;
            Restaurant.IdRestaurant = entity.IdRestaurant;
            Restaurant.IdClub = entity.IdClub;
            Restaurant.NomRestaurant = entity.NomRestaurant;
            Restaurant.DescriptionRestaurant = entity.DescriptionRestaurant;
            Restaurant.ClubNavigation = entity.ClubNavigation;
            Restaurant.PhotoNavigation = entity.PhotoNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Restaurant Restaurant)
        {
            medDBContext.Restaurants.Remove(Restaurant);
            await medDBContext.SaveChangesAsync();
        }
    }
}
