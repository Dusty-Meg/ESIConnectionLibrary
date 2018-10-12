using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestWarsEndpoints
    {
        V1WarsWar War(int warId);
        Task<V1WarsWar> WarAsync(int warId);
        IList<V1WarsKillmail> Killmails(int warId);
        Task<IList<V1WarsKillmail>> KillmailsAsync(int warId);
        IList<int> Wars(int maxWarId = 0);
        Task<IList<int>> WarsAsync(int maxWarId = 0);
    }
}