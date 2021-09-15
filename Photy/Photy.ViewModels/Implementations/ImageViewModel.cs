using Avalonia.Media.Imaging;
using Photy.ViewModels.Interfaces;

namespace Photy.ViewModels.Implementations
{
    public class ImageViewModel : ViewModelBase, IImageViewModel
    {
        private readonly Bitmap? _bitmap;

        public ImageViewModel(Bitmap? bitmap)
        {
            _bitmap = bitmap;
        }

        public Bitmap? Image => _bitmap;
    }
}