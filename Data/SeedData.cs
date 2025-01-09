using CDRMS_Web_Application.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task SeedRolesAndAdmin(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<UsersModel>>();

        // Seed Roles
        var roles = new[] { "Admin", "Super User","User" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // Seed Admin User
        var adminName = "System Administrator";
        var adminEmail = "admin@pronet-tech.net";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            var user = new UsersModel
            {
                FullName = adminName,
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                IsFirstLogin = false,
                PhoneNumberConfirmed = true,
                LockoutEnabled = false,
            };

            var result = await userManager.CreateAsync(user, "Admin@123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                throw new Exception($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }
}
