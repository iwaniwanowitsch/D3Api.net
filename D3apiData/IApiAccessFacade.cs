using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3apiData.API;
using D3apiData.API.Objects;
using D3apiData.Repositories;

namespace D3apiData
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
