using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class CarteBancaireManager : IDataRepository<CarteBancaire>
    {
        readonly MedDBContext? medDBContext;
        public CarteBancaireManager() { }
        public CarteBancaireManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<CarteBancaire>>> GetAllAsync()
        {
            return await medDBContext.CarteBancaires.ToListAsync();
        }
        public async Task<ActionResult<CarteBancaire>> GetByIdAsync(int id)
        {
            return await medDBContext.CarteBancaires.FirstOrDefaultAsync(u => u.IdCarteBancaire == id);
        }
        public async Task<ActionResult<CarteBancaire>> GetByStringAsync(string intitule)
        {
            return await medDBContext.CarteBancaires.FirstOrDefaultAsync(u => u.NumeroCB.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(CarteBancaire entity)
        {
            await medDBContext.CarteBancaires.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(CarteBancaire CarteBancaire, CarteBancaire entity)
        {
            medDBContext.Entry(CarteBancaire).State = EntityState.Modified;
            CarteBancaire.IdCarteBancaire = entity.IdCarteBancaire;
            CarteBancaire.NumeroCB = entity.NumeroCB;
            CarteBancaire.DateExpirationCB = entity.DateExpirationCB;
            CarteBancaire.DetientNavigation = entity.DetientNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(CarteBancaire CarteBancaire)
        {
            medDBContext.CarteBancaires.Remove(CarteBancaire);
            await medDBContext.SaveChangesAsync();
        }
    }
}
