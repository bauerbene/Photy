using Photy.Services.Avanlonia.Implementations;
using Photy.Services.Avanlonia.Interfaces;
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
            services.RegisterLazySingleton<IEnvironmentProcessService>(() => new EnvironmentProcessService());
            services.RegisterLazySingleton<IEnvironmentFileService>(() => new EnvironmentFileService());
            services.RegisterLazySingleton<IEnvironmentDirectoryService>(() => new EnvironmentDirectoryService());
            services.RegisterLazySingleton<IBitmapService>(() => new BitmapService());
            
            //services.RegisterLazySingleton<IExifService>(() => new ExifService());
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
            var fileService = resolver.GetRequiredService<IEnvironmentFileService>();
            services.RegisterLazySingleton<IEnvironmentFileService>(() =>
                new EnvironmentWindowsFileService(fileService)
            );
            // services.RegisterLazySingleton<IEnvironmentDirectoryService>(() =>
            //    new EnvironmentDirectoryServiceWindowsDecorator(
            //        new EnvironmentDirectoryService()
            //    )
            // );
        }
    }
}