using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WorldUniversity.Areas.Identity.IdentityHostingStartup))]
namespace WorldUniversity.Areas.Identity
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