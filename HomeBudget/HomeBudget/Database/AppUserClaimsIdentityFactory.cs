using HomeBudget.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace HomeBudget.Database
{
    public class AppUserClaimsIdentityFactory : ClaimsIdentityFactory<AppUser>
    {
        public override async Task<ClaimsIdentity> CreateAsync(
            UserManager<AppUser, string> manager,
            AppUser user,
            string authenticationType)
        {
            var identity = await base.CreateAsync(manager, user, authenticationType);
            identity.AddClaim(new Claim("MonthBudget", user.MonthBudget));
            identity.AddClaim(new Claim("MyName", user.Name));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.Surname));
            return identity;
        }
    }
}