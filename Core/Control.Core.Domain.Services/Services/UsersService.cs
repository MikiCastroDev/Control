using Control.Infrastructure.Domain.Models.DTOs;

namespace Control.Core.Domain.Services
{
    public class UsersService
    {
        public UsersService() { }

        public List<UserDTO> GetAllUsers()
        {
            return new();
        }
    }
}
