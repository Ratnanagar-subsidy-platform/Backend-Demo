

using NetWares.Dtos;
using NetWares.Interfaces.Repository;
using NetWares.Interfaces.Service;
using NetWares.Mappers;

namespace NetWares.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GenericRepository methods

        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => u.ToReadDto());
        }

        public async Task<UserReadDto> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"user for given id {id} not found");
            return user.ToReadDto();
        }

        public async Task<UserReadDto> AddAsync(UserCreateDto dto)
        {
            var user = dto.ToEntity();
            var createdUser = await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return createdUser.ToReadDto();
        }

        public async Task<UserReadDto> UpdateAsync(int id, UserUpdateDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id)?? throw new KeyNotFoundException($"user for given id {id} not found");

            user.UpdateFromDto(dto);
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            return user.ToReadDto();
        }

        public async Task<UserReadDto> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id)?? throw new KeyNotFoundException($"user for given id {id} not found");

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
            return user.ToReadDto();
        }

        public async Task SaveChangesAsync()
        {
            await _userRepository.SaveChangesAsync();
        }

        // IUserRepository specific methods

        public async Task<UserReadDto> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email) ?? throw new KeyNotFoundException($"user for given email {email} not found");
            return user.ToReadDto();
        }

        public async Task<UserReadDto> SignUpAsync(UserCreateDto dto)
        {
            var user = dto.ToEntity();
            var createdUser = await _userRepository.SignUpAsync(user, dto.Password);
            await _userRepository.SaveChangesAsync();
            return createdUser.ToReadDto();
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            return await _userRepository.LoginAsync(email, password);
        }
    }
}