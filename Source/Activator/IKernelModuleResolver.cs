using Ninject;
using Ninject.Modules;

namespace Devices.Activator
{
    public interface IKernelModuleResolver
    {
        IKernel ResolveKernel(params NinjectModule[] modules);
    }
}
