namespace D3ApiDotNet.Core.NotifyPropertyChanged
{
    public interface IRaisePropertyChanged
    {
        void RaisePropertyChanged(string propertyName);
    }
}
