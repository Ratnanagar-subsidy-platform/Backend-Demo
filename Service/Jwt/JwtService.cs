using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetWares.Configurations;
using NetWares.Data;

namespace NetWares.Service.Jwt
{

    public class JwtService(IOptions<JwtOption> config) : IJwtService
    {
        private readonly JwtOption _config = config.Value;

        public string GenerateJwtToken(IdentityUser user)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.UTF8.GetBytes(_config.SecretKey);

                var claims = new ClaimsIdentity([
                    new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub,
                    user.Email ?? throw new ArgumentNullException(nameof(user), "User's Email cannot be null")),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
            ]);

                /*
                    A token descriptor describes the properites and values to be in the token
                */
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Issuer = _config.Issuer,
                    Audience = _config.Audience,
                    SigningCredentials =
                        new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };
                var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = jwtTokenHandler.WriteToken(token);


                // //  creating a new refresh token
                // var refreshToken = new RefreshToken()
                // {
                //     JwtId = token.Id,
                //     Token = RandomStringGenerator(23), // Generate a refresh token
                //     ExpiryDate = DateTime.UtcNow.AddMonths(6),
                //     UserId = user.Id,
                //     IsRevoked = false,
                //     IsUsed = false,
                //     AddedDate = DateTime.UtcNow,
                // };

                // adding the refresh token to the database
                // await _context.RefreshTokens.AddAsync(refreshToken);
                // await _context.SaveChangesAsync();

                return jwtToken;
            }
            catch (Exception ex)
            {
                throw new Exception($"Server Error {ex.Message}");
            }
        }
    }
}