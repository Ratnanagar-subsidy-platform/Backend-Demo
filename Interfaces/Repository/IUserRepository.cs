
using NetWares.Models;

namespace NetWares.Interfaces.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User> SignUpAsync(User user, string password);
        Task<string> LoginAsync(string email, string password);
    }
}