using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class ClientManager : IDataRepository<Client>
    {
        readonly MedDBContext? medDBContext;
        public ClientManager() { }
        public ClientManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Client>>> GetAllAsync()
        {
            return await medDBContext.Clients.ToListAsync();
        }
        public async Task<ActionResult<Client>> GetByIdAsync(int id)
        {
            return await medDBContext.Clients.FirstOrDefaultAsync(u => u.IdClient == id);
        }
        public async Task<ActionResult<Client>> GetByStringAsync(string emailOrLogin)
        {
            return await medDBContext.Clients.FirstOrDefaultAsync(u => u.MailClient.ToUpper() == emailOrLogin.ToUpper() || u.LoginClient.ToUpper() == emailOrLogin.ToUpper());
        }
        public async Task AddAsync(Client entity)
        {
            await medDBContext.Clients.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Client client, Client entity)
        {
            medDBContext.Entry(client).State = EntityState.Modified;
            client.IdClient = entity.IdClient;
            client.GenreClient = entity.GenreClient;
            client.NomClient = entity.NomClient;
            client.PrenomClient = entity.PrenomClient;
            client.DateNaissanceClient = entity.DateNaissanceClient;
            client.MailClient = entity.MailClient;
            client.TelClient = entity.TelClient;
            client.AdresseClient = entity.AdresseClient;
            client.CodePostalClient = entity.CodePostalClient;
            client.VilleClient = entity.VilleClient;
            client.PaysClient = entity.PaysClient;
            client.LoginClient = entity.LoginClient;
            client.PasswordClient = entity.PasswordClient;
            client.TypeclientNavigation = entity.TypeclientNavigation;
            client.ReservationNavigation = entity.ReservationNavigation;
            client.AviNavigation = entity.AviNavigation;
            client.DetientNavigation = entity.DetientNavigation;
            client.ReponseNavigation = entity.ReponseNavigation;
            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Client client)
        {
            medDBContext.Clients.Remove(client);
            await medDBContext.SaveChangesAsync();
        }
    }
}