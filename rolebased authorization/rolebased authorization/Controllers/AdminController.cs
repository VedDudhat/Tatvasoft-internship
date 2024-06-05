using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace rolebased_authorization.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet("data")]
        public IActionResult GetAdminData()
        {
            return Ok(new { Message = "This is secure admin data" });
        }
    }

    [Authorize(Policy = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("data")]
        public IActionResult GetUserData()
        {
            return Ok(new { Message = "This is secure user data" });
        }
    }

}
