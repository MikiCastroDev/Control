using Microsoft.AspNetCore.Mvc;

namespace Control.Core.UI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        [HttpGet]
        public string GetInfo()
        {
            return "Empresa de prueba";
        }
    }
}
