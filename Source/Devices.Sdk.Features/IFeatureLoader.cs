using Devices.Common;

namespace Devices.Sdk.Features
{
    //internal interface IFeatureLoader
    public interface IFeatureLoader
    {
        IFeature[] LoadFeatures(string featureDirectoryPath);
    }
}
