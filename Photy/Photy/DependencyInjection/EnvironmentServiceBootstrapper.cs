using Microsoft.CodeAnalysis;
using Photy.Services.Environment.Implementations;
using Photy.Services.Environment.Interfaces;
using Splat;

namespace Photy.DependencyInjection
{
    public static class EnvironmentServicesBootstrapper
    {
        public static void RegisterEnvironmentServices(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            RegisterCommonServices(services);
            RegisterPlatformSpecificServices(services, resolver);
        }

        private static void RegisterCommonServices(IMutableDependencyResolver services)
        {
            services.RegisterLazySingleton<IProcessService>(() => new ProcessService());
            services.RegisterLazySingleton<IFileService>(() => new FileService());
            services.RegisterLazySingleton<IDirectoryService>(() => new DirectoryService());
        }

        private static void RegisterPlatformSpecificServices(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            // var platformService = resolver.GetRequiredService<IPlatformService>();
            // var platform = platformService.GetPlatform();
            
            // if (platform is Platform.Windows)
            // {
            //     RegisterWindowsServices(services, resolver);
            // }
        }

        private static void RegisterWindowsServices(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            var fileService = resolver.GetRequiredService<IFileService>();
            services.RegisterLazySingleton<IFileService>(() =>
                new WindowsFileService(fileService)
            );
            // services.RegisterLazySingleton<IEnvironmentDirectoryService>(() =>
            //    new EnvironmentDirectoryServiceWindowsDecorator(
            //        new EnvironmentDirectoryService()
            //    )
            // );
        }
    }
}