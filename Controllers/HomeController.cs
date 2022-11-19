using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RBMS.Helpers;

namespace RBMS.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Authorizer("Home")]
        public IActionResult Get()
        {
            return Ok(new {status = "success", message = "This is Home Page" });
        }
    }
}
