using Control.Infrastructure.Domain.Models.DTOs;
using Control.Infrastructure.Util.WebApi;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Control.Core.Domain.Services
{
    public class UsersService : BaseAppService
    {
        public UsersService(IServiceProvider serviceProvider, ILogger<UsersService> logger) : base(serviceProvider, logger) { }

        public Result<List<UserDTO>> GetAllUsers()
        {
            _logger.LogMethodInfo(MethodBase.GetCurrentMethod());

            List<UserDTO> users = new();
            return ProcessOk(users, true);
        }
    }
}
