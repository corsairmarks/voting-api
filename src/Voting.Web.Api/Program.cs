using System;
using Microsoft.AspNetCore.Hosting;

namespace Voting.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:5000", "https://*:5001")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}