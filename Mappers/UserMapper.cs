using NetWares.Dtos;
using NetWares.Models;

namespace NetWares.Mappers
{
    public static class UserMapper
    {
        // Map from UserCreateDto to User entity (for creating new user)
        public static User ToEntity(this UserCreateDto dto)
        {
            return new User
            {
                FullName = dto.FullName,
                Contact = dto.Contact,
                Email = dto.Email,
                UserName = dto.Email // typically username = email
            };
        }

        // Map from User entity to UserReadDto (for reading user data)
        public static UserReadDto ToReadDto(this User user)
        {
            return new UserReadDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Contact = user.Contact,
                Email = user.Email
            };
        }

        // Update existing User entity from UserUpdateDto
        public static void UpdateFromDto(this User user, UserUpdateDto dto)
        {
            user.FullName = dto.FullName;
            user.Contact = dto.Contact;
            // do not update Email here unless explicitly needed
        }
    }
}