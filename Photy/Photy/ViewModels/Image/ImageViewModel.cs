using Avalonia.Media.Imaging;

namespace Photy.ViewModels.Image
{
    public class ImageViewModel : ViewModelBase
    {
        private readonly Bitmap? _bitmap;

        public ImageViewModel(Bitmap? bitmap)
        {
            _bitmap = bitmap;
        }

        public Bitmap? Image => _bitmap;

    }
}