using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestKillmailsEndpoints : ILatestKillmailsEndpoints
    {
        private readonly IInternalLatestKillmails _internalLatestKillmails;

        public LatestKillmailsEndpoints(string userAgent)
        {
            _internalLatestKillmails = new InternalLatestKillmails(null, userAgent);
        }

        public V1GetSingleKillmail GetSingleKillmail(int killmailId, string killmailHash)
        {
            return _internalLatestKillmails.GetSingleKillmail(killmailId, killmailHash);
        }

        public async Task<V1GetSingleKillmail> GetSingleKillmailAsync(int killmailId, string killmailHash)
        {
            return await _internalLatestKillmails.GetSingleKillmailAsync(killmailId, killmailHash);
        }
    }
}
