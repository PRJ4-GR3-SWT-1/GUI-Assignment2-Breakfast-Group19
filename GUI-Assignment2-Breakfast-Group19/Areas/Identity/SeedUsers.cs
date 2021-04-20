using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GUI_Assignment2_Breakfast_Group19.Areas.Identity
{
    public class SeedUsers
    {
        public static void SeedTheUsers(UserManager<IdentityUser> userManager)
        {
            // Not currently working
         /*   const string receptionEmail = "Receptionist@email.com";
            const string receptionPassword = "rR1234%";

            if (userManager.FindByNameAsync(receptionEmail).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = receptionEmail;
                user.Email = receptionEmail;
                IdentityResult result = userManager.CreateAsync(user, receptionPassword).Result;

                if (result.Succeeded)
                {
                    var Occupationclaim = new Claim("Occupation", "Reception");
                    userManager.AddClaimAsync(user, Occupationclaim);
                    userManager.AddToRoleAsync(user, "Reception").Wait();
                }
            }*/
        }
    }
    
}
