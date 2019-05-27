using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestKillmailsEndpoints : ILatestKillmailsEndpoints
    {
        private readonly IInternalLatestKillmails _internalLatestKillmails;

        public LatestKillmailsEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestKillmails = new InternalLatestKillmails(null, userAgent, testing);
        }

        internal LatestKillmailsEndpoints(string userAgent, IWebClient webClient, bool testing = false)
        {
            _internalLatestKillmails = new InternalLatestKillmails(webClient, userAgent, testing);
        }

        public IList<V1KillmailCharacter> Character(SsoToken token, int page)
        {
            return _internalLatestKillmails.Character(token, page);
        }

        public async Task<IList<V1KillmailCharacter>> CharacterAsync(SsoToken token, int page)
        {
            return await _internalLatestKillmails.CharacterAsync(token, page);
        }

        public IList<V1KillmailCorporation> Corporation(SsoToken token, int corporationId, int page)
        {
            return _internalLatestKillmails.Corporation(token, corporationId, page);
        }

        public async Task<IList<V1KillmailCorporation>> CorporationAsync(SsoToken token, int corporationId, int page)
        {
            return await _internalLatestKillmails.CorporationAsync(token, corporationId, page);
        }

        public V1KillmailKillmail Killmail(int killmailId, string killmailHash)
        {
            return _internalLatestKillmails.Killmail(killmailId, killmailHash);
        }

        public async Task<V1KillmailKillmail> KillmailAsync(int killmailId, string killmailHash)
        {
            return await _internalLatestKillmails.KillmailAsync(killmailId, killmailHash);
        }
    }
}
