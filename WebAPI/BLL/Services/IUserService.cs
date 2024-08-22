using Common.DTOs;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(RegisterDto registerDto);
    }
}
