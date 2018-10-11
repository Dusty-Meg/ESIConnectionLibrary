using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestKillmailsEndpoints
    {
        IList<V1KillmailCharacter> Character(SsoToken token, int page);
        Task<IList<V1KillmailCharacter>> CharacterAsync(SsoToken token, int page);
        IList<V1KillmailCorporation> Corporation(SsoToken token, int corporationId, int page);
        Task<IList<V1KillmailCorporation>> CorporationAsync(SsoToken token, int corporationId, int page);
        V1KillmailKillmail Killmail(int killmailId, string killmailHash);
        Task<V1KillmailKillmail> KillmailAsync(int killmailId, string killmailHash);
    }
}