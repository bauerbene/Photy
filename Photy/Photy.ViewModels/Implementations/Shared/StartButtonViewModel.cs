using System;
using Photy.ViewModels.Interfaces.Shared;

namespace Photy.ViewModels.Implementations.Shared
{
    public class StartButtonViewModel : ViewModelBase, IStartButtonViewModel
    {
        public string ButtonText { get; set; }
        public Action OnButtonClicked { get; set; }

        public void OnClick()
        {
            OnButtonClicked();
        }
    }
}