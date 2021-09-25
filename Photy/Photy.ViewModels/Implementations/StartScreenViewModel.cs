using System;
using Photy.ViewModels.Implementations.Shared;
using Photy.ViewModels.Interfaces;

namespace Photy.ViewModels.Implementations
{
    public class StartScreenViewModel : ViewModelBase, IStartScreenViewModel
    {
        private const string StartViewerButtonText = "Start Viewer";
        private const string StartTaggerButtonText = "Start Tagger";

        public void OnStartViewerButtonClicked()
        {
            StartViewer();
        }

        public void OnStartTaggerButtonClicked()
        {
            StartTagger();
        }

        public StartScreenViewModel()
        {
            StartViewerButton = new StartButtonViewModel
            {
                ButtonText = StartViewerButtonText,
                OnButtonClicked = OnStartViewerButtonClicked
            };
            StartTaggerButton = new StartButtonViewModel
            {
                ButtonText = StartTaggerButtonText,
                OnButtonClicked = OnStartTaggerButtonClicked
            };
        }

        public ViewModelBase StartViewerButton { get; }

        public ViewModelBase StartTaggerButton { get; }
        
        public Action StartViewer { get; set; }
        
        public Action StartTagger { get; set; }
    }
}