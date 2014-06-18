using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace D3ApiDotNet.Core.NotifyPropertyChanged
{
    public abstract class BaseNotifyPropertyChanged : INotifyPropertyChanged, IRaisePropertyChanged
    {
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        void IRaisePropertyChanged.RaisePropertyChanged(string propertyName)
        {
            RaisePropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
