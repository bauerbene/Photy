using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Photy.Views.Image
{
    public class ImageView : UserControl
    {
        public ImageView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}