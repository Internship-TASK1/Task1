using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs;
namespace BLL.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginModel loginModel);
    }
}
