using Common.DTOs;

namespace BLL.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginModel loginModel);
    }
}
