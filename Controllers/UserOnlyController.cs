using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RBMS.Helpers;

namespace RBMS.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserOnlyController : ControllerBase
    {
        [Authorizer("UserOnly")]
        public IActionResult Get()
        {
            return Ok(new { status = "success", message = "This is User only Page" });
        }
    }
}
