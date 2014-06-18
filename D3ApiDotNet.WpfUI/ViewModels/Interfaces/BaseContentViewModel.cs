using System;
using System.Windows.Input;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace D3ApiDotNet.WpfUI.ViewModels.Interfaces
{
    public interface IRaisePropertyChanged
    {
        void RaisePropertyChanged(string propertyName);
    }

    public static class RaisePropertyChangedExtensions
    {

        public static void SetValueIfChanged<T>(this IRaisePropertyChanged target, ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            SetValueIfChanged(target, ref field, value, EqualityComparer<T>.Default, propertyName);
        }

        public static void SetValueIfChanged<T>(this IRaisePropertyChanged target, ref T field, T value, IEqualityComparer<T> equalityComparer, [CallerMemberName]string propertyName = null)
        {
            if (equalityComparer.GetHashCode(field) == equalityComparer.GetHashCode(value) &&
                equalityComparer.Equals(field, value))
                return;

            field = value;
            target.RaisePropertyChanged(propertyName);
        }
    }

    public abstract class BaseContentViewModel : IContentViewModel, INotifyPropertyChanged, IRaisePropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;
        
        void IRaisePropertyChanged.RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
