using System;

namespace Devices.Sdk.Features
{
    public interface IFeature : IDisposable
    {
        string Name { get; }
    }
}
