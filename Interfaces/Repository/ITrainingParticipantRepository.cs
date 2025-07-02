using NetWares.Models;

namespace NetWares.Interfaces.Repository
{
    public interface ITrainingParticipantRepository : IGenericRepository<TrainingParticipant>
    {
        Task<TrainingParticipant?> GetByCitizenship(string citizenship);
    }
}