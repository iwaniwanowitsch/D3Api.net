using System;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.ViewModels;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.Commands
{
    public class ManageContentViewModelActions : IManageContentViewModelActions
    {
        private readonly Action<IContentViewModel> _action;
        private readonly Action<IContentViewModel> _removeContent;

        public ManageContentViewModelActions([NotNull] Action<IContentViewModel> addContent,
            [NotNull] Action<IContentViewModel> removeContent)
        {
            if (addContent == null) throw new ArgumentNullException("addContent");
            if (removeContent == null) throw new ArgumentNullException("removeContent");
            _action = addContent;
            _removeContent = removeContent;
        }

        public void AddContentViewModel(IContentViewModel contentViewModel)
        {
            _action(contentViewModel);
        }

        public void RemoveContentViewModel(IContentViewModel contentViewModel)
        {
            _removeContent(contentViewModel);
        }
    }
}