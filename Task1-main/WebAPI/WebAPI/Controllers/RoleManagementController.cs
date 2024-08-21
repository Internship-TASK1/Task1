using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using DAL.Entities;
using Common.DTOs; // Đảm bảo thêm chỉ thị này

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleManagementController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleManagementController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromBody] CreateRoleDto model)
        {
            if (string.IsNullOrWhiteSpace(model.RoleName))
            {
                return BadRequest("Role name cannot be empty.");
            }

            if (await _roleManager.RoleExistsAsync(model.RoleName))
            {
                return BadRequest("Role already exists.");
            }

            var result = await _roleManager.CreateAsync(new IdentityRole(model.RoleName));
            if (result.Succeeded)
            {
                return Ok(new { message = "Role created successfully." });
            }

            return BadRequest(result.Errors);
        }
        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            if (!await _roleManager.RoleExistsAsync(model.RoleName))
            {
                return BadRequest("Role does not exist.");
            }

            var result = await _userManager.AddToRoleAsync(user, model.RoleName);
            if (result.Succeeded)
            {
                return Ok(new { message = "Role assigned successfully." });
            }

            return BadRequest(result.Errors);
        }
    }
}
