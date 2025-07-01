
using NetWares.Data;
using NetWares.Interfaces.Repository;
using NetWares.Models;

namespace NetWares.Repository
{
public class TrainingRepository : GenericRepository<Training>, ITrainingRepository
{
    public TrainingRepository(AppDbContext context) : base(context) { }
}
}