using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Photy.Views.Shared
{
    public class StartButtonView : UserControl
    {
        public StartButtonView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}