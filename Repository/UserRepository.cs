using NetWares.Data;
using NetWares.Models;
using NetWares.Interfaces.Repository;
using NetWares.Service.Jwt;

namespace NetWares.Repository
{
public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;

        public UserRepository(
            AppDbContext context, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            IJwtService jwtService) : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> SignUpAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            return user;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await GetByEmailAsync(email) ?? throw new AuthenticationException("Invalid Credentials");

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded) throw new AuthenticationException("Invalid Credentials");

            return _jwtService.GenerateJwtToken(user);
        }
    }
}