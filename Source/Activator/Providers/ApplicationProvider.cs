using Ninject;

namespace Devices.Activator.Providers
{
    internal class ApplicationProvider : IApplicationProvider
    {
        public IApplication GetApplication()
        {
            Application application = new Application();

            using IKernel kernel = new KernelResolver().ResolveKernel();
            kernel.Inject(application);

            return application;
        }
    }
}
