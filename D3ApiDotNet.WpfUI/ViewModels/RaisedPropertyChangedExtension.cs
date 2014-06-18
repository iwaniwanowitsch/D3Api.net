using D3ApiDotNet.WpfUI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace D3ApiDotNet.WpfUI.ViewModels
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
