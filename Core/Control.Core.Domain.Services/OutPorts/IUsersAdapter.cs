using Control.Infrastructure.Domain.Models.DTOs;

namespace Control.Core.Domain.OutPorts
{
    public interface IUsersAdapter
    {
        UserDTO? GetUser(string email, string password);
    }
}
