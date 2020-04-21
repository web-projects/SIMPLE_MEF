using System.Composition;
using static Devices.Common.SupportedDevices;

namespace Devices.Sdk.Features
{
    [Export(typeof(IFeature))]
    [Export(Verifone_UX300_Device, typeof(IFeature))]
    [Export(Verifone_UX301_Device, typeof(IFeature))]
    public class AdaFeatureImpl : IAppWorkflowFeature
    {
        public string Name { get; } = Verifone_UX301_Device;

        public void Dispose()
        {
            // Nothing to dispose of
        }

        public string GetAvailableStateActions()
        {
            return "test";
        }
    }
}
