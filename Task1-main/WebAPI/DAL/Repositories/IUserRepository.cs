using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetUserByUsernameAsync(string username);
        Task AddUserAsync(ApplicationUser user);
    }
}
