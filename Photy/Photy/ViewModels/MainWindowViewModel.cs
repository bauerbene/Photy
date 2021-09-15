using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;
using Photy.Services.Avanlonia.Interfaces;
using Photy.Services.Environment.Interfaces;
using Photy.ViewModels.Image;
using Photy.Views.Image;

namespace Photy.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IBitmapService _bitmapService;
        private readonly IDirectoryService _directoryService;

        private ObservableCollection<ImageViewModel> _images = new();

        public MainWindowViewModel(IBitmapService bitmapService, IDirectoryService directoryService)
        {
            _bitmapService = bitmapService;
            _directoryService = directoryService;
        }

        public ObservableCollection<ImageViewModel> Images
        {
            get
            {
                _images = LoadImages();
                return _images;
            }
        }

        private ObservableCollection<ImageViewModel> LoadImages()
        {
            ObservableCollection<ImageViewModel> images = new();
            const string path = "/home/kali/sicherung/DCIM/test/";
            var files = _directoryService.EnumerateFilesRecursivelyByTypes(path, new[] {"jpg"});
            var bitmaps = _bitmapService.GetBitmapsByPaths(files);
            foreach (var bitmap in bitmaps)
            {
                images.Add(new ImageViewModel(bitmap));
            }

            return images;
        }
    }
}