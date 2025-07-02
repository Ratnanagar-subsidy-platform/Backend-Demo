
using Microsoft.EntityFrameworkCore;
using NetWares.Data;
using NetWares.Interfaces.Repository;
using NetWares.Models;

namespace NetWares.Repository
{
    public class TrainingParticipantRepository : GenericRepository<TrainingParticipant>, ITrainingParticipantRepository
    {
        public TrainingParticipantRepository(AppDbContext context) : base(context) { }
        public async Task<TrainingParticipant?> GetByCitizenship(string citizenship)
        {
            var data = await _dbSet.FirstOrDefaultAsync(d => d.CitizenshipNumber == citizenship);
            return data;
        }
    }
}