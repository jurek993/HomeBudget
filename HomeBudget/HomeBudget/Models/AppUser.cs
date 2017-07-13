using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MonthBudget { get; set; }

        //example
        //[InverseProperty("Seller")]
        //public virtual ICollection<Book> SellingBooks { get; set; }
        //[InverseProperty("Buyer")]
        //public virtual ICollection<Book> BuyingBooks { get; set; }
    }
}