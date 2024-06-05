using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace rolebased_authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet("create")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (roleResult.Succeeded)
                {
                    return Ok(new { Message = "Role created successfully" });
                }
                return BadRequest(roleResult.Errors);
            }
            return BadRequest(new { Message = "Role already exists" });
        }
    }

}
