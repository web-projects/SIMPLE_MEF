using Devices.Activator;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Devices.Core
{
    class Program
    {
        static readonly AppActivator activator = new AppActivator();

        private static readonly string featurePluginDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Features");

        static async Task Main(string[] args)
        {
            IApplication application = activator.Start(featurePluginDirectory);
            await application.Run().ConfigureAwait(false);

            Console.WriteLine("PRESS 'Q' to QUIT...");

            while (Console.ReadKey().Key != ConsoleKey.Q)
            {
                await Task.Delay(50).ConfigureAwait(false);
            }

            application.Shutdown();
        }
    }
}
