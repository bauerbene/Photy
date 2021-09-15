using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Photy.Services.Environment.Implementations;
using Photy.Services.Environment.Interfaces;
using Splat;

namespace Photy
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();

        private void RegisterServices(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            
            services.RegisterLazySingleton<IProcessService>(() => new ProcessService());
            services.RegisterLazySingleton<IDirectoryService>(() => new DirectoryService());
            services.RegisterLazySingleton<IFileService>(() => new FileService());
        }
    }
}