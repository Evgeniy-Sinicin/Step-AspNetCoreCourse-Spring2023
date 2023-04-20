using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Presentation.Web.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Shop.Presentation.Web.Areas.Identity.IdentityHostingStartup))]
namespace Shop.Presentation.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ShopDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ShopDbContextConnection")));

                services.AddDefaultIdentity<ShopUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()    
                .AddEntityFrameworkStores<ShopDbContext>();
            });
        }
    }
}