using Photy.Services.Avanlonia.Interfaces;
using Photy.Services.Environment.Interfaces;
using Photy.ViewModels.Implementations;
using Photy.ViewModels.Implementations.Image;
using Photy.ViewModels.Interfaces;
using Splat;

namespace Photy.DependencyInjection
{
    public class ViewModelsBootstrapper
    {
        public static void RegisterViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            RegisterCommonViewModels(services, resolver);
        }

        private static void RegisterCommonViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            var bitmapService = resolver.GetRequiredService<IBitmapService>();
            var directoryService = resolver.GetRequiredService<IDirectoryService>();
            services.Register<IMainWindowViewModel>(() => new MainWindowViewModel(
                bitmapService,
                directoryService
            ));
            
            services.Register<IImageViewModel>(() => new ImageViewModel());
        }
    }
}