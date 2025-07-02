using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetWares.Dtos
{
    public class UserCreateDto
    {
        public string FullName { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class UserReadDto
    {
        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class UserUpdateDto
    {
        public string FullName { get; set; } = null!;
        public string Contact { get; set; } = null!;
    }
}