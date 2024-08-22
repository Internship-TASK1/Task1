using Common.DTOs;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IUserRepository userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<bool> RegisterAsync(RegisterDto registerDto)
        {
            // Kiểm tra xem người dùng đã tồn tại chưa
            var existingUser = await _userRepository.GetUserByUsernameAsync(registerDto.UserName);
            if (existingUser != null)
            {
                return false; // Người dùng đã tồn tại
            }

            // Tạo người dùng mới
            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                FullName = registerDto.FullName,
                CreatedTime = DateTimeOffset.UtcNow
            };

            // Hash mật khẩu
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                return true; // Đăng ký thành công
            }

            return false; // Đăng ký không thành công
        }
    }
}
