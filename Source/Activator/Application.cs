using Devices.Common;
using Devices.Sdk.Features;
using Ninject;
using System;
using System.Threading.Tasks;

namespace Devices.Activator
{
    internal class Application : IApplication
    {
        [Inject]
        internal IFeatureLoader featureLoader { get; set; }

        private string featuresPath;

        public void Initialize(string featuresPath) => (this.featuresPath) = (featuresPath);

        public Task Run()
        {
            _ = Task.Run(() =>
            {
                IFeature[] features = featureLoader.LoadFeatures(featuresPath);
                foreach (var feature in features)
                {
                    Console.WriteLine($"FEATURE FOUND: {feature.Name}");
                }
            });

            return Task.CompletedTask;
        }

        public void Shutdown()
        {

        }
    }
}
