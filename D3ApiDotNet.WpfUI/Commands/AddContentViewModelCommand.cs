using System;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.ViewModels;

namespace D3ApiDotNet.WpfUI.Commands
{
    public class AddContentViewModelCommand : IAddContentViewModelCommand
    {
        private readonly Action<IContentViewModel> _action;

        public AddContentViewModelCommand([NotNull] Action<IContentViewModel> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            _action = action;
        }

        public void AddContentViewModel(IContentViewModel contentViewModel)
        {
            _action(contentViewModel);
        }
    }
}