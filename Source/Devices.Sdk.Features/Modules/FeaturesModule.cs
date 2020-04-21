using Devices.Sdk.Features.Internal.AppFeatures;
using Ninject.Modules;

namespace Devices.Sdk.Features.Modules
{
    public class FeaturesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFeatureLoader>().To<FeatureLoaderImpl>();
        }
    }
}
