using AuditInspect.Models.FormModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuditInspect.Utility
{
    public static class MyIdentityDataInitializer
    {

        public static void SeedData
(UserManager<ApplicationUser> userManager,
RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }


        public static void SeedUsers
    (UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync
                ("rogojinacosmin@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "rogojinacosmin@gmail.com";
                user.Email = "rogojinacosmin@gmail.com";
                user.EmailConfirmed = true;

                //user.FullName = "Nancy Davolio";
                //user.BirthDate = new DateTime(1960, 1, 1);

                IdentityResult result = userManager.CreateAsync
                (user, "Qwerty12!@").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Admin").Wait();

                }


            }
            if (userManager.FindByNameAsync
                ("test1@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "test1@gmail.com";
                user.Email = "test1@gmail.com";
                user.EmailConfirmed = true;

                //user.FullName = "Nancy Davolio";
                //user.BirthDate = new DateTime(1960, 1, 1);

                IdentityResult result = userManager.CreateAsync
                (user, "Qwerty12!@").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Admin").Wait();

                }


            }


            if (userManager.FindByNameAsync
                ("test2@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "test2@gmail.com";
                user.Email = "test2@gmail.com";
                user.EmailConfirmed = true;

                //user.FullName = "Nancy Davolio";
                //user.BirthDate = new DateTime(1960, 1, 1);

                IdentityResult result = userManager.CreateAsync
                (user, "Qwerty12!@").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Admin").Wait();

                }


            }
        }


        public static void SeedRoles
    (RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync
("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";

                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync
("Agent").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Agent";

                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync
("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";

                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
