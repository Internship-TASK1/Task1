using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using DAL.Entities;

namespace WebAPI.Initialization
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

              // create roles
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
               // new roles
                    var roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                    if (!roleResult.Succeeded)
                    {
                        throw new Exception($"Failed to create role {roleName}");
                    }
                }
            }

            // create account
            var username = "admin";
            var password = "Admin123!";
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = username,
                    
                };
                var userResult = await userManager.CreateAsync(user, password);
                if (!userResult.Succeeded)
                {
                    throw new Exception($"Failed to create user {username}");
                }
            }

            // 
            if (!await userManager.IsInRoleAsync(user, "Admin"))
            {
                var result = await userManager.AddToRoleAsync(user, "Admin");
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to assign Admin role to user");
                }
            }
        }
    }
}
