using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class KillmailsEndpoints : IKillmailsEndpoints
    {
        private readonly IInternalKillmails _internalKillmails;

        public KillmailsEndpoints(string userAgent)
        {
            _internalKillmails = new InternalKillmails(null, userAgent);
        }

        public GetSingleKillmail GetSingleKillmail(int killmailId, string killmailHash)
        {
            return _internalKillmails.GetSingleKillmail(killmailId, killmailHash);
        }
    }
}
