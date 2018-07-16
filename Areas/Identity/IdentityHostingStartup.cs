using System;
using FantasyWealth.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FantasyWealth.Areas.Identity.IdentityHostingStartup))]
namespace FantasyWealth.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FantasyWealthIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FantasyWealthIdentityDbContextConnection")));

                services.AddDefaultIdentity<FantasyWealthUser>()
                    .AddEntityFrameworkStores<FantasyWealthIdentityDbContext>();
            });
        }
    }
}