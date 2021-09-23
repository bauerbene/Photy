using System.Collections.ObjectModel;
using Photy.Services.Avanlonia.Interfaces;
using Photy.Services.Environment.Interfaces;
using Photy.ViewModels.Implementations.Image;
using Photy.ViewModels.Interfaces;

namespace Photy.ViewModels.Implementations
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly IBitmapService _bitmapService;
        private readonly IDirectoryService _directoryService;

        private ObservableCollection<IImageViewModel> _images = new();

        public MainWindowViewModel(
            IBitmapService bitmapService, 
            IDirectoryService directoryService
        )
        {
            _bitmapService = bitmapService;
            _directoryService = directoryService;
        }

        public ObservableCollection<IImageViewModel> Images
        {
            get
            {
                _images = LoadImages();
                return _images;
            }
        }

        private ObservableCollection<IImageViewModel> LoadImages()
        {
            ObservableCollection<IImageViewModel> images = new();
            const string path = "/home/kali/sicherung/DCIM/test/";
            var files = _directoryService.EnumerateFilesRecursivelyByTypes(path, new[] {"jpg"});
            var bitmaps = _bitmapService.GetBitmapsByPaths(files);
            foreach (var bitmap in bitmaps)
            {
                images.Add(new ImageViewModel
                {
                    Image = bitmap
                });
            }

            return images;
        }
    }
}