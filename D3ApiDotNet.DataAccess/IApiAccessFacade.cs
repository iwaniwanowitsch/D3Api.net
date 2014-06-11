using System.IO;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.DataAccess.Repositories;

namespace D3ApiDotNet.DataAccess
{
    public interface IApiAccessFacade
    {
        CollectMode CollectMode { get; set; }

        ProfileRepository ProfileRepository { get; }

        HeroRepository HeroRepository { get; }

        ItemRepository ItemRepository { get; }

        FollowerRepository FollowerRepository { get; }

        ArtisanRepository ArtisanRepository { get; }

        SkillIconRepository SkillIconRepository { get; }

        ItemIconRepository ItemIconRepository { get; }

        IReadonlyRepository<Stream, string> ReadRepo { get; set; }

    }
}
