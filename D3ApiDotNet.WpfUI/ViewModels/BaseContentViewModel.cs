using System;
using System.Windows.Input;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.ViewModels
{

    public abstract class BaseContentViewModel : BaseViewModel, IContentViewModel
    {
        private readonly IManageContentViewModelActions _manageContentViewModelActions;
        private readonly bool _isDeletable;
        private ICommand _deleteCommand;

        protected BaseContentViewModel([NotNull] IManageContentViewModelActions manageContentViewModelActions, bool isDeletable, bool isLoading)
        {
            if (manageContentViewModelActions == null) throw new ArgumentNullException("manageContentViewModelActions");
            _manageContentViewModelActions = manageContentViewModelActions;
            _isDeletable = isDeletable;
            IsLoading = isLoading;
        }

        public abstract string Name { get; }

        private bool _isLoading;
        public virtual bool IsLoading { 
            get { return _isLoading; }
            set { this.SetValueIfChanged(ref _isLoading, value); }
        }

        public virtual ICommand Delete
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(
                        param =>_manageContentViewModelActions.RemoveContentViewModel(this),
                        param => _isDeletable
                    );
                }
                return _deleteCommand;
            }
        }
    }
}
