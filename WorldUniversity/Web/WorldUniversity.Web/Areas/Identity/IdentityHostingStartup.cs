using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WorldUniversity.Web.Areas.Identity.IdentityHostingStartup))]
namespace WorldUniversity.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}