using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3ApiDotNet.Core.Objects.Artisan;
using D3ApiDotNet.Core.Objects.Follower;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.Core.Objects.Images;
using D3ApiDotNet.Core.Objects.Item;
using D3ApiDotNet.Core.Objects.Profile;

namespace D3ApiDotNet.DataAccess.API.UrlConstruction.Factories
{
    class UrlConstructionProviderFactory : IUrlConstructionProviderFactory
    {
        private readonly Dictionary<Type, Func<Locales, IUrlConstructionProvider>> _constructionProviders = new Dictionary<Type, Func<Locales, IUrlConstructionProvider>>
        {
            {typeof(Profile), o => new ProfileUrlConstructionProvider(o)},
            {typeof(Hero), o => new HeroUrlConstructionProvider(o)},
            {typeof(Item), o => new ItemUrlConstructionProvider(o)},
            {typeof(Artisan), o => new ArtisanUrlConstructionProvider(o)},
            {typeof(Follower), o => new FollowerUrlConstructionProvider(o)},
            {typeof(D3Icon), o => new IconUrlConstructionProvider(o)}
        }; 

        public IUrlConstructionProvider CreateUrlConstructionProvider(Locales locale, Type t)
        {
            return _constructionProviders[t](locale);
        }
    }
}
