using Blade.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Blade.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .UseIdHelper()
                .UseLog()
                .UseCache()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseUrls("http://*:5000")
                        .UseStartup<Startup>();
                })
                .Build()
                .Run();
        }
    }
}
