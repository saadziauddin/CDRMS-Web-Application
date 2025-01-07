using CDRMS_Web_Application.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task SeedRolesAndAdmin(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // Seed Roles
        var roles = new[] { "Admin", "User" };
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
            var user = new ApplicationUser
            {
                FullName = adminName,
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                LockoutEnabled = false,
                AccessFailedCount = 0
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
