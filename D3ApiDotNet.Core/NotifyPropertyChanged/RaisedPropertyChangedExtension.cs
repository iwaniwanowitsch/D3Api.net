using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace D3ApiDotNet.Core.NotifyPropertyChanged
{
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
}
