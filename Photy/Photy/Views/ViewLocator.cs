using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Photy.ViewModels.Implementations;

namespace Photy.Views
{
    public class ViewLocator : IDataTemplate
    {
        public IControl Build(object param)
        {
            var fullName = param.GetType().FullName;
            if (fullName is null)
            {
                throw new InvalidOperationException("Full name for type was not found");
            }

            var name = fullName
                .Replace("Photy.ViewModels.Implementations", "Photy.Views")
                .Replace("ViewModel", "View");

            var type = Type.GetType(name);
            if (type is null)
            {
                throw new InvalidOperationException($"Type {name} was not found");
            }

            var control = Activator.CreateInstance(type);
            if (control is null)
            {
                throw new InvalidOperationException(
                    $"Control for type {type} with name {name} could not be created"
                );
            }

            return (Control) control;
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}