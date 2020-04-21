using Devices.Activator.Providers;
using Ninject.Modules;

namespace Devices.Activator.Modules
{
    public class AppModules : NinjectModule
    {
        public override void Load()
        {
            Bind<IApplicationProvider>().To<ApplicationProvider>();
        }
    }
}
