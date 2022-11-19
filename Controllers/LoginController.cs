using Microsoft.AspNetCore.Mvc;
using RBMS.Helpers;
using RBMS.Models;
using System.Threading.Tasks;

namespace RBMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AuthHelper _authHelper;

        public LoginController(AuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Credentials credentials)
        {
            if (!await _authHelper.Authenticate(credentials))
                return Unauthorized();

            return Ok( new {Status = "success", _authHelper.Token });
        }
    }
}
