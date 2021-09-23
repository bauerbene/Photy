using Photy.Configuration;
using Splat;

namespace Photy.DependencyInjection
{
    public class Bootstrapper
    {
        public static void Register(
            IMutableDependencyResolver services, 
            IReadonlyDependencyResolver resolver, 
            DataAccessConfiguration dataAccessConfiguration
        )
        {
            EnvironmentServicesBootstrapper.RegisterEnvironmentServices(services, resolver);
            ViewModelsBootstrapper.RegisterViewModels(services, resolver);
            
        }
    }
}