using System;
using D3apiData.API.Objects;

namespace D3apiData.API.UrlConstruction.Factories
{
    interface IUrlConstructionProviderFactory
    {
        IUrlConstructionProvider CreateUrlConstructionProvider(Locales locale, Type t);
    }
}
