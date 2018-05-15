using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestWarsEndpoints : ILatestWarsEndpoints
    {
        private readonly IInternalLatestWars _internalLatestWars;

        public LatestWarsEndpoints(string userAgent)
        {
            _internalLatestWars = new InternalLatestWars(null, userAgent);
        }

        public IList<int> GetWars(int maxWarId = 0)
        {
            return _internalLatestWars.GetWars(maxWarId);
        }

        public async Task<IList<int>> GetWarsAsync(int maxWarId = 0)
        {
            return await _internalLatestWars.GetWarsAsync(maxWarId);
        }

        public V1WarsIndividualWar GetIndividualWar(int warId)
        {
            return _internalLatestWars.GetIndividualWar(warId);
        }

        public async Task<V1WarsIndividualWar> GetIndividualWarAsync(int warId)
        {
            return await _internalLatestWars.GetIndividualWarAsync(warId);
        }

        public IList<V1WarsWarKillmails> GetIndividualWarsKillmails(int warId)
        {
            return _internalLatestWars.GetIndividualWarsKillmails(warId);
        }

        public async Task<IList<V1WarsWarKillmails>> GetIndividualWarsKillmailsAsync(int warId)
        {
            return await _internalLatestWars.GetIndividualWarsKillmailsAsync(warId);
        }
    }
}
