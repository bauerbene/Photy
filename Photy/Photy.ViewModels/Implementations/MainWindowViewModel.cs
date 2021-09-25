
using System;
using System.Collections.Generic;
using System.Linq;
using Photy.Services.Avanlonia.Interfaces;
using Photy.Services.Environment.Interfaces;
using Photy.Services.Interfaces;
using Photy.ViewModels.Implementations.Image;
using Photy.ViewModels.Implementations.Shared;
using Photy.ViewModels.Interfaces;
using ReactiveUI;

namespace Photy.ViewModels.Implementations
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private ViewModelBase _content;

        private readonly IBitmapService _bitmapService;
        private readonly IEnvironmentDirectoryService _environmentDirectoryService;
        private readonly IExifService _exifService;

        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public void StartViewer()
        {
            
            const string path = "/home/kali/sicherung/DCIM/test/";
            var files = _environmentDirectoryService.EnumerateFilesRecursivelyByTypes(path, new[] {"jpg"});
            var bitmaps = _bitmapService.GetBitmapsByPaths(new List<string>{files.First()});
            Content = new ImageViewModel
            {
                Image = bitmaps.First()
            };
        }

        public void StartTagger()
        {
            const string path = "/home/kali/sicherung/DCIM/test/";
            var files = _environmentDirectoryService.EnumerateFilesRecursivelyByTypes(path, new[] {"jpg"}).ToList();
            var bitmaps = _bitmapService.GetBitmapsByPaths(new List<string>{files.First()});
            Content = new ImageViewModel
            {
                Image = bitmaps.First()
            };
        }

        public MainWindowViewModel(
            IBitmapService bitmapService, 
            IEnvironmentDirectoryService environmentDirectoryService,
            IExifService exifService)
        {
            _bitmapService = bitmapService;
            _environmentDirectoryService = environmentDirectoryService;
            _exifService = exifService;
            _content = new StartScreenViewModel
            {
                StartTagger = StartTagger,
                StartViewer = StartViewer
            };
        }
    }
}

/*using System.Collections.ObjectModel;
using Photy.Services.Avanlonia.Interfaces;
using Photy.Services.Environment.Interfaces;
using Photy.ViewModels.Implementations.Image;
using Photy.ViewModels.Interfaces;

namespace Photy.ViewModels.Implementations
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly IBitmapService _bitmapService;
        private readonly IEnvironmentDirectoryService _environmentDirectoryService;

        private ObservableCollection<IImageViewModel> _images = new();

        public MainWindowViewModel(
            IBitmapService bitmapService, 
            IEnvironmentDirectoryService environmentDirectoryService
        )
        {
            _bitmapService = bitmapService;
            _environmentDirectoryService = environmentDirectoryService;
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
            var files = _environmentDirectoryService.EnumerateFilesRecursivelyByTypes(path, new[] {"jpg"});
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
}*/