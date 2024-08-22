using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(
                loginModel.UserName,
                loginModel.Password,
                isPersistent: false, // Giữ trạng thái đăng nhập
                lockoutOnFailure: false // Khóa tài khoản khi thất bại
            );

            return result.Succeeded; // Trả về kết quả đăng nhập
        }
    }
}
