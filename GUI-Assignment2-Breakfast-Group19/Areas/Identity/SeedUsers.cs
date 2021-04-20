using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GUI_Assignment2_Breakfast_Group19.Areas.Identity
{
    public class SeedUsers
    {
        public static void SeedTheUsers(UserManager<IdentityUser> userManager)
        {
            const string receptionEmail = "Reception@email.com";
            const string receptionPassword = "rR1234%";

            if (userManager.FindByNameAsync(receptionEmail).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = receptionEmail;
                user.Email = receptionEmail;
                IdentityResult result = userManager.CreateAsync(user, receptionPassword).Result;

            }
        }
    }
    
}
