using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestWars
    {
        V1WarsWar War(int warId);
        Task<V1WarsWar> WarAsync(int warId);
        IList<V1WarsKillmail> Killmails(int warId);
        Task<IList<V1WarsKillmail>> KillmailsAsync(int warId);
        IList<int> Wars(int maxWarId);
        Task<IList<int>> WarsAsync(int maxWarId);
    }
}