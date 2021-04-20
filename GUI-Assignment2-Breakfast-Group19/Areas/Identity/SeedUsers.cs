﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GUI_Assignment2_Breakfast_Group19.Areas.Identity
{
    public class SeedUsers
    {
        public static async void SeedTheUsers(UserManager<IdentityUser> userManager)
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

                    userManager.AddToRoleAsync(user, "Reception").Wait();
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

                    userManager.AddToRoleAsync(user, "Servant").Wait();
                }
            }

        }
    }
    
}
