using Devices.Common;
using Ninject;
using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

namespace Devices.Sdk.Features.Internal.AppFeatures
{
    internal sealed class FeatureLoaderImpl : IFeatureLoader, IInitializable
    {
        public void Initialize()
        {

        }

        private ContainerConfiguration CreateContainerConfiguration(string featureDirectoryPath)
        {
            ContainerConfiguration container = new ContainerConfiguration();

            if (!Directory.Exists(featureDirectoryPath))
            {
                return container;
            }

            var availableAssemblies = Directory
                .GetFiles(featureDirectoryPath, "*.dll", SearchOption.AllDirectories)
                .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                .ToList();

            return container.WithAssemblies(availableAssemblies);
        }

        public IFeature[] LoadFeatures(string featureDirectoryPath)
        {
            List<IFeature> features = new List<IFeature>();

            try
            {
                using CompositionHost container = CreateContainerConfiguration(featureDirectoryPath).CreateContainer();
                IEnumerable<IFeature> discoveredFeatures = container.GetExports<IFeature>();

                if (discoveredFeatures != null && discoveredFeatures.Count() > 0)
                {
                    features.AddRange(discoveredFeatures);
                }
            }
            catch (CompositionFailedException ex)
            {
                //_ = loggingServiceClient.LogErrorAsync("Feature discovery failed on composition builder.", ex);
            }
            catch (Exception ex)
            {
                //_ = loggingServiceClient.LogErrorAsync("An error occurred while attempting to compose plugin discovery.", ex);
            }

            return features.ToArray();
        }
    }
}
