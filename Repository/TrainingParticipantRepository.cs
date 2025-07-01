
using NetWares.Data;
using NetWares.Interfaces.Repository;
using NetWares.Models;

namespace NetWares.Repository
{
public class TrainingParticipantRepository :GenericRepository<TrainingParticipant>, ITrainingParticipantRepository
{
    public TrainingParticipantRepository(AppDbContext context) : base(context) { }
}
}