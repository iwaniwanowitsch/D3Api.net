using System;

namespace D3ApiDotNet.DataAccess.API.UrlConstruction.Factories
{
    interface IUrlConstructionProviderFactory
    {
        IUrlConstructionProvider CreateUrlConstructionProvider(Locales locale, Type t);
    }
}
