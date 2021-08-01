using Microsoft.AspNetCore.Identity;
using WorldUniversity.Models;

namespace WorldUniversity.Data
{
    public static class IdentityDataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("user@wumail.bg").Result == null)
            {
                var user = new ApplicationUser();
                user.FirstName = "Ivan";
                user.LastName = "Ivanov";
                user.UserName = "user@wumail.bg";
                user.Email = "user@wumail.bg";
                user.EmailConfirmed = true;
                var result = userManager.CreateAsync(user, "12345678").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (userManager.FindByNameAsync("admin@wumail.bg").Result == null)
            {
                var user = new ApplicationUser();
                user.FirstName = "Ivan";
                user.LastName = "Ivanov";
                user.UserName = "admin@wumail.bg";
                user.Email = "admin@wumail.bg";
                user.EmailConfirmed = true;
                var result = userManager.CreateAsync(user, "12345678").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByNameAsync("mod@wumail.bg").Result == null)
            {
                var user = new ApplicationUser();
                user.FirstName = "Hasan";
                user.LastName = "Hasan123";
                user.UserName = "mod@wumail.bg";
                user.Email = "mod@wumail.bg";
                user.EmailConfirmed = true;
                var result = userManager.CreateAsync(user, "12345678").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Moderator").Wait();
                }
            }
        }
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "Perform normal operations.";
                var roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "Perform all the operations.";
                var roleResult = roleManager.
                CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Moderator").Result)
            {
                var role = new IdentityRole();
                role.Name = "Moderator";
                role.NormalizedName = "Perform some the operations.";
                var roleResult = roleManager.
                CreateAsync(role).Result;
            }

        }
    }
}
