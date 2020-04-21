using System.Threading.Tasks;

namespace Devices.Activator
{
    public interface IApplication
    {
        void Initialize(string featuresPath);
        Task Run();
        void Shutdown();
    }
}
