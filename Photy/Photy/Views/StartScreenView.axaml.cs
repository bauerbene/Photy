using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Photy.Views
{
    public class StartScreenView : UserControl
    {
        public StartScreenView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}