using Microsoft.AspNetCore.Identity;

namespace Shop.Presentation.Web.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ShopUser class
    public class ShopUser : IdentityUser
    {
        public string ImagePath { get; set; }
    }
}
