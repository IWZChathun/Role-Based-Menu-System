using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RBMS.Helpers;

namespace RBMS.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AdminOnlyController : ControllerBase
    {
        [Authorizer("AdminOnly")]
        public IActionResult Get()
        {
            return Ok(new { status = "success", message = "This is Admin Only" });
        }
    }
}
