using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GUI_Assignment2_Breakfast_Group19.Areas.Identity
{
    public static class SeedUsers
    {
        public static async Task SeedTheUsers(UserManager<IdentityUser> userManager)
        {

            const string receptionEmail = "Receptionist@email.com";
            const string receptionPassword = "rR1234%";

            if (userManager.FindByNameAsync(receptionEmail).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = receptionEmail;
                user.Email = receptionEmail;
                user.EmailConfirmed = true;
                IdentityResult result = await userManager.CreateAsync(user, receptionPassword);

                if (result.Succeeded)
                {
                    var nameclaim = new Claim("FullName", "TheReceptionist");
                    await userManager.AddClaimAsync(user, nameclaim);

                    var Occupationclaim = new Claim("Occupation", "Reception");
                    await userManager.AddClaimAsync(user, Occupationclaim);

                  //  userManager.AddToRoleAsync(user, "Reception").Wait();
                }
            }

            const string ServantEmail = "Servant@email.com";
            const string ServantPassword = "sS1234%";

            if (userManager.FindByNameAsync(ServantEmail).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = ServantEmail;
                user.Email = ServantEmail;
                user.EmailConfirmed = true;
                IdentityResult result = await userManager.CreateAsync(user, ServantPassword);

                if (result.Succeeded)
                {
                    var nameclaim = new Claim("FullName", "TheServant");
                    await userManager.AddClaimAsync(user, nameclaim);

                    var Occupationclaim = new Claim("Occupation", "Servant");
                    await userManager.AddClaimAsync(user, Occupationclaim);

                   // userManager.AddToRoleAsync(user, "Servant").Wait();
                }
            }

            const string kitchenEmail = "kitchen@email.com";
            const string kitchenPassword = "kK1234%";

            if (userManager.FindByNameAsync(kitchenEmail).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = kitchenEmail;
                user.Email = kitchenEmail;
                user.EmailConfirmed = true;
                IdentityResult result = await userManager.CreateAsync(user, kitchenPassword);

                if (result.Succeeded)
                {
                    var nameclaim = new Claim("FullName", "TheKitchen");
                    await userManager.AddClaimAsync(user, nameclaim);

                    var Occupationclaim = new Claim("Occupation", "Kitchen");
                    await userManager.AddClaimAsync(user, Occupationclaim);

                   // userManager.AddToRoleAsync(user, "Kitchen").Wait();
                }
            }

            const string adminEmail = "admin@email.com";
            const string adminPassword = "aA1234%";

            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = adminEmail;
                user.Email = adminEmail;
                user.EmailConfirmed = true;
                IdentityResult result = await userManager.CreateAsync(user, adminPassword);

                if (result.Succeeded)
                {
                    var nameclaim = new Claim("FullName", "TheAdmin");
                    await userManager.AddClaimAsync(user, nameclaim);

                    var Occupationclaim = new Claim("Occupation", "Admin");
                    await userManager.AddClaimAsync(user, Occupationclaim);

                   // userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

        }
    }
    
}
