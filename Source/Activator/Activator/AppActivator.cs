using Devices.Activator.Providers;
using Ninject;
using System;

namespace Devices.Activator
{
    public class AppActivator
    {
        [Inject]
        internal IApplicationProvider ApplicationProvider { get; set; }

        public AppActivator()
        {
            using (IKernel kernel = new KernelResolver().ResolveKernel())
            {
                kernel.Inject(this);
            }
        }

        public IApplication Start(string pluginPath)
        {
            if (string.IsNullOrWhiteSpace(pluginPath))
            {
                throw new ArgumentNullException(nameof(pluginPath));
            }

            IApplication application = ApplicationProvider.GetApplication();
            application.Initialize(pluginPath);
            return application;
        }
    }
}
