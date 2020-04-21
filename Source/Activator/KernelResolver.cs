using Devices.Activator.Modules;
using Devices.Sdk.Features.Modules;
using Ninject;
using Ninject.Modules;
using System.Collections.Generic;

namespace Devices.Activator
{
    internal class KernelResolver : IKernelModuleResolver
    {
        private const int NumberOfKnownModules = 2;

        public IKernel ResolveKernel(params NinjectModule[] modules)
        {
            List<NinjectModule> moduleList;

            if (modules != null && modules.Length > 0)
            {
                moduleList = new List<NinjectModule>(NumberOfKnownModules + modules.Length);
                moduleList.AddRange(modules);
            }
            else
            {
                moduleList = new List<NinjectModule>(NumberOfKnownModules);
            }

            moduleList.Add(new AppModules());
            moduleList.Add(new FeaturesModule());

            IKernel kernel = new StandardKernel(moduleList.ToArray());

            kernel.Settings.InjectNonPublic = true;
            kernel.Settings.InjectParentPrivateProperties = true;

            return kernel;
        }
    }
}