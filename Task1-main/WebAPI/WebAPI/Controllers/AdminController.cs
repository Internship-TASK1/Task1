using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // Phương thức này chỉ có thể truy cập bởi người dùng có vai trò "Admin"
        [HttpGet("admin-only")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminData()
        {
            return Ok(new { message = "This is admin data" });
        }

        // Phương thức này có thể truy cập bởi người dùng có vai trò "Admin" hoặc "User"
        [HttpGet("user-or-admin")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetUserOrAdminData()
        {
            return Ok(new { message = "This is data for admin or user" });
        }
    }
}
