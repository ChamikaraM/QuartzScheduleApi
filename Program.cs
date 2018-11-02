using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace QuartzScheduleApi
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            StartScheduler(); // add this line

            host.Run();
        }

        // add this method
        private static void StartScheduler()
        {


        }
    }
}