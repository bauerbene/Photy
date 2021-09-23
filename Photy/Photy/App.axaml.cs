using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Photy.DependencyInjection;
using Photy.ViewModels.Interfaces;
using Photy.Views;
using Splat;

namespace Photy
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindowView()
                {
                    DataContext = Locator.Current.GetRequiredService<IMainWindowViewModel>()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}