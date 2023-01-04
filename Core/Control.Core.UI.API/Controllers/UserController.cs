using Control.Core.Domain.Services;
using Control.Infrastructure.Domain.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Control.Core.UI.API.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UserController(UsersService usersService)
        {
            this._usersService = usersService;
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> GetUserList()
        {
            try
            {
                return Ok(_usersService.GetAllUsers());
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
    }
}
