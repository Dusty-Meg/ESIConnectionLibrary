using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestContactsEndpoints
    {
        PagedModel<V2ContactAlliance> Alliance(SsoToken token, int allianceId, int page);
        Task<PagedModel<V2ContactAlliance>> AllianceAsync(SsoToken token, int allianceId, int page);
        IList<V1ContactAllianceLabel> AllianceLabels(SsoToken token, int allianceId);
        Task<IList<V1ContactAllianceLabel>> AllianceLabelsAsync(SsoToken token, int allianceId);
        PagedModel<V2ContactCharacter> Character(SsoToken token, int page);
        IList<int> CharacterAdd(SsoToken token, V2ContactCharacterAdd model);
        Task<IList<int>> CharacterAddAsync(SsoToken token, V2ContactCharacterAdd model);
        Task<PagedModel<V2ContactCharacter>> CharacterAsync(SsoToken token, int page);
        void CharacterDelete(SsoToken token, IList<int> contactIds);
        Task CharacterDeleteAsync(SsoToken token, IList<int> contactIds);
        void CharacterEdit(SsoToken token, V2ContactCharacterEdit model);
        Task CharacterEditAsync(SsoToken token, V2ContactCharacterEdit model);
        IList<V1ContactCharacterLabel> CharacterLabels(SsoToken token);
        Task<IList<V1ContactCharacterLabel>> CharacterLabelsAsync(SsoToken token);
        PagedModel<V2ContactCorporation> Corporation(SsoToken token, int corporationId, int page);
        Task<PagedModel<V2ContactCorporation>> CorporationAsync(SsoToken token, int corporationId, int page);
        IList<V1ContactCorporationLabel> CorporationLabels(SsoToken token, int corporationId);
        Task<IList<V1ContactCorporationLabel>> CorporationLabelsAsync(SsoToken token, int corporationId);
    }
}