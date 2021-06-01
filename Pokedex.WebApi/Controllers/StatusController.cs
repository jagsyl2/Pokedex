using Microsoft.AspNetCore.Mvc;

namespace Pokedex.WebApi.Controllers
{
    [Route("api/status")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public string GetStatus()
        {
            return "Status Ok";
        }
    }
}
