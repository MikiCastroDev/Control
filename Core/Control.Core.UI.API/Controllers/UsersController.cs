using Control.Core.Domain.Services;
using Control.Infrastructure.Domain.Models.DTOs;
using Control.Infrastructure.Domain.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Control.Core.UI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControlSpecialController
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            this._usersService = usersService;
        }

        #region Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserDTO> Login([FromBody] LoginRequest request)
        {
            return ProcessResult(_usersService.Login(request));
        }
        #endregion

        [HttpGet]
        public ActionResult<List<UserDTO>> GetUserList()
        {
            return ProcessResult(_usersService.GetAllUsers());
        }
    }
}
