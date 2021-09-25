using System;
using JetBrains.Annotations;
using Photy.ViewModels.Interfaces.Shared;

namespace Photy.ViewModels.Implementations.Shared
{
    public class TestButtonViewModel : ViewModelBase, ITestButtonViewModel
    {
        public Action OnClickProp { get; set; }

        public void Test()
        {
            OnClick();
        }

        public void OnClick()
        {
            OnClickProp();
        }

        public object ButtonText
        {
            get { throw new NotImplementedException(); }
        }
    }
}