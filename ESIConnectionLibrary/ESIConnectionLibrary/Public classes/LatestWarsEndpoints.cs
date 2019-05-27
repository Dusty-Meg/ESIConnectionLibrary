using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestWarsEndpoints : ILatestWarsEndpoints
    {
        private readonly IInternalLatestWars _internalLatestWars;

        public LatestWarsEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestWars = new InternalLatestWars(null, userAgent, testing);
        }

        internal LatestWarsEndpoints(string userAgent, IWebClient webClient, bool testing = false)
        {
            _internalLatestWars = new InternalLatestWars(webClient, userAgent, testing);
        }

        public IList<int> Wars(int maxWarId = 0)
        {
            return _internalLatestWars.Wars(maxWarId);
        }

        public async Task<IList<int>> WarsAsync(int maxWarId = 0)
        {
            return await _internalLatestWars.WarsAsync(maxWarId);
        }

        public V1WarsWar War(int warId)
        {
            return _internalLatestWars.War(warId);
        }

        public async Task<V1WarsWar> WarAsync(int warId)
        {
            return await _internalLatestWars.WarAsync(warId);
        }

        public IList<V1WarsKillmail> Killmails(int warId)
        {
            return _internalLatestWars.Killmails(warId);
        }

        public async Task<IList<V1WarsKillmail>> KillmailsAsync(int warId)
        {
            return await _internalLatestWars.KillmailsAsync(warId);
        }
    }
}
