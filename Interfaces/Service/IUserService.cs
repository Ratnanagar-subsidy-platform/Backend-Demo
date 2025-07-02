
using NetWares.Dtos;

namespace NetWares.Interfaces.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetAllAsync();
        Task<UserReadDto> GetByIdAsync(int id);
        Task<UserReadDto> AddAsync(UserCreateDto dto);
        Task<UserReadDto> UpdateAsync(int id, UserUpdateDto dto);
        Task<UserReadDto> DeleteAsync(int id);
        Task SaveChangesAsync();

        Task<UserReadDto> GetByEmailAsync(string email);
        Task<UserReadDto> SignUpAsync(UserCreateDto dto);
        Task<string> LoginAsync(string email, string password);
    }
}