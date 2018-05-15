using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestWarsEndpoints
    {
        V1WarsIndividualWar GetIndividualWar(int warId);
        Task<V1WarsIndividualWar> GetIndividualWarAsync(int warId);
        IList<V1WarsWarKillmails> GetIndividualWarsKillmails(int warId);
        Task<IList<V1WarsWarKillmails>> GetIndividualWarsKillmailsAsync(int warId);
        IList<int> GetWars(int maxWarId = 0);
        Task<IList<int>> GetWarsAsync(int maxWarId = 0);
    }
}