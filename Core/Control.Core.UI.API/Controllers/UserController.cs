using Control.Core.Domain.Services;
using Control.Infrastructure.Domain.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Control.Core.UI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControlSpecialController
    {
        private readonly UsersService _usersService;

        public UserController(UsersService usersService)
        {
            this._usersService = usersService;
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> GetUserList()
        {
            return ProcessResult(_usersService.GetAllUsers());
        }
    }
}
