using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace HomeBudget.Database
{
    public class AppUserPrincipal : ClaimsPrincipal
    {
        public AppUserPrincipal(ClaimsPrincipal principal)
            : base(principal)
        {
        }

        public string Username
        {
            get
            {
                return this.FindFirst(ClaimTypes.Name).Value;
            }
        }

        public string Name
        {
            get
            {
                return this.FindFirst("MyName").Value;
            }
        }

        public string Surname
        {
            get
            {
                return this.FindFirst(ClaimTypes.Surname).Value;
            }
        }

        public string MonthBudget
        {
            get
            {
                return this.FindFirst("MonthBudget").Value;
            }
        }
    }
}