using APISAE401.Models.EntityFramework;
using APISAE401.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.DataManager
{
    public class ParticipantManager : IDataRepository<Participant>
    {
        readonly MedDBContext? medDBContext;
        public ParticipantManager() { }
        public ParticipantManager(MedDBContext context)
        {
            medDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Participant>>> GetAllAsync()
        {
            return await medDBContext.Participants.ToListAsync();
        }
        public async Task<ActionResult<Participant>> GetByIdAsync(int id)
        {
            return await medDBContext.Participants.FirstOrDefaultAsync(u => u.IdParticipant == id);
        }
        public async Task<ActionResult<Participant>> GetByStringAsync(string intitule)
        {
            return await medDBContext.Participants.FirstOrDefaultAsync(u => u.NomParticipant.ToUpper() == intitule.ToUpper());
        }
        public async Task AddAsync(Participant entity)
        {
            await medDBContext.Participants.AddAsync(entity);
            await medDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Participant Participant, Participant entity)
        {
            medDBContext.Entry(Participant).State = EntityState.Modified;
            Participant.IdParticipant = entity.IdParticipant;
            Participant.GenreParticipant = entity.GenreParticipant;
            Participant.NomParticipant = entity.NomParticipant;
            Participant.PrenomParticipant = entity.PrenomParticipant;
            Participant.DateNaissanceParticipant = entity.DateNaissanceParticipant;
            Participant.ParticiperNavigation = entity.ParticiperNavigation;

            await medDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Participant Participant)
        {
            medDBContext.Participants.Remove(Participant);
            await medDBContext.SaveChangesAsync();
        }
    }
}
