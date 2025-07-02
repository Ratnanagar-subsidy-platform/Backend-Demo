

using Microsoft.AspNetCore.Identity;

namespace NetWares.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public override required string Email { get; set; } = null!;
    }
}