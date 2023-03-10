using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class TypeclientManager : IDataRepository<TypeClient>
    {
        readonly MedDBContext? medDBContext;
        public TypeclientManager() { }
        public TypeclientManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<TypeClient>>> GetAllAsync()
        {
            return await medDBContext.TypeClients.ToListAsync();
        }
        public async Task<ActionResult<TypeClient>> GetByIdAsync(int id)
        {
            return await medDBContext.TypeClients.FirstOrDefaultAsync(u => u.IdTypeClient == id);
        }
        public async Task<ActionResult<TypeClient>> GetByStringAsync(string intitule)
        {
            return await medDBContext.TypeClients.FirstOrDefaultAsync(u => u.IntituleTypeClient.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(TypeClient entity)
        {
            await medDBContext.TypeClients.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TypeClient typeclient, TypeClient entity)
        {
            medDBContext.Entry(typeclient).State = EntityState.Modified;
            typeclient.IdTypeClient = entity.IdTypeClient;
            typeclient.IntituleTypeClient = entity.IntituleTypeClient;
            typeclient.ClientNavigation = entity.ClientNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(TypeClient typeclient)
        {
            medDBContext.TypeClients.Remove(typeclient);
            await medDBContext.SaveChangesAsync();
        }
    }
}