﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3ApiDotNet.WpfUI.ViewModels.Interfaces
{
    public interface IRaisePropertyChanged
    {
        void RaisePropertyChanged(string propertyName);
    }
}
