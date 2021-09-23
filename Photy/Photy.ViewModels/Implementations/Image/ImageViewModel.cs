using Avalonia.Media.Imaging;
using Photy.ViewModels.Interfaces;

namespace Photy.ViewModels.Implementations.Image
{
    public class ImageViewModel : ViewModelBase, IImageViewModel
    {

        public ImageViewModel()
        {
        }

        public Bitmap Image { get; set; }
    }
}