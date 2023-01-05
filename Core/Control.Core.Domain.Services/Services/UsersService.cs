using Control.Core.Domain.OutPorts;
using Control.Infrastructure.Domain.Models.DTOs;
using Control.Infrastructure.Domain.Models.Request;
using Control.Infrastructure.Util.WebApi;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Control.Core.Domain.Services
{
    public class UsersService : BaseAppService
    {
        private readonly IUsersAdapter _adapter;
        private readonly TokenService _tokenService;

        public UsersService(IServiceProvider serviceProvider
                            , ILogger<UsersService> logger
                            , IUsersAdapter adapter
                            , TokenService tokenService) : base(serviceProvider, logger) 
        {
            _adapter = adapter;
            _tokenService = tokenService;
        }

        public Result<UserDTO> Login(LoginRequest request)
        {
            _logger.LogMethodInfo(MethodBase.GetCurrentMethod());

            if(string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return Result.Fail<UserDTO>(Result.ErrorLocatingUser());

            UserDTO? userFinder = _adapter.GetUser(request.Email, request.Password);
            if(userFinder == null)
                return ProcessFail<UserDTO>(Result.Fail<UserDTO>(Result.ErrorLocatingUser()));

            userFinder.Token = _tokenService.GenerateToken(userFinder.Id);

            return ProcessOk(userFinder, true);
        }

        public Result<List<UserDTO>> GetAllUsers()
        {
            _logger.LogMethodInfo(MethodBase.GetCurrentMethod());

            List<UserDTO> users = new();
            return ProcessOk(users, true);
        }
    }
}
