

using Microsoft.AspNetCore.Identity;

namespace NetWares.Service.Jwt
{
    public interface IJwtService
    {
        string GenerateJwtToken(IdentityUser user);

    }
}