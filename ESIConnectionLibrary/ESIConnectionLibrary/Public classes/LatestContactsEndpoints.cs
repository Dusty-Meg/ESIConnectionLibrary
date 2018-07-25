using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestContactsEndpoints : ILatestContactsEndpoints
    {
        private readonly IInternalLatestContacts _internalLatestContacts;

        public LatestContactsEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestContacts = new InternalLatestContacts(null, userAgent, testing);
        }

        public PagedModel<V2ContactAlliance> Alliance(SsoToken token, int allianceId, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return _internalLatestContacts.Alliance(token, allianceId, page);
        }

        public async Task<PagedModel<V2ContactAlliance>> AllianceAsync(SsoToken token, int allianceId, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return await _internalLatestContacts.AllianceAsync(token, allianceId, page);
        }

        public IList<V1ContactAllianceLabel> AllianceLabels(SsoToken token, int allianceId)
        {
            return _internalLatestContacts.AllianceLabels(token, allianceId);
        }

        public async Task<IList<V1ContactAllianceLabel>> AllianceLabelsAsync(SsoToken token, int allianceId)
        {
            return await _internalLatestContacts.AllianceLabelsAsync(token, allianceId);
        }

        public void CharacterDelete(SsoToken token, IList<int> contactIds)
        {
            _internalLatestContacts.CharacterDelete(token, contactIds);
        }

        public async Task CharacterDeleteAsync(SsoToken token, IList<int> contactIds)
        {
            await _internalLatestContacts.CharacterDeleteAsync(token, contactIds);
        }

        public PagedModel<V2ContactCharacter> Character(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return _internalLatestContacts.Character(token, page);
        }

        public async Task<PagedModel<V2ContactCharacter>> CharacterAsync(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return await _internalLatestContacts.CharacterAsync(token, page);
        }

        public IList<int> CharacterAdd(SsoToken token, V2ContactCharacterAdd model)
        {
            return _internalLatestContacts.CharacterAdd(token, model);
        }

        public async Task<IList<int>> CharacterAddAsync(SsoToken token, V2ContactCharacterAdd model)
        {
            return await _internalLatestContacts.CharacterAddAsync(token, model);
        }

        public void CharacterEdit(SsoToken token, V2ContactCharacterEdit model)
        {
            _internalLatestContacts.CharacterEdit(token, model);
        }

        public async Task CharacterEditAsync(SsoToken token, V2ContactCharacterEdit model)
        {
            await _internalLatestContacts.CharacterEditAsync(token, model);
        }

        public IList<V1ContactCharacterLabel> CharacterLabels(SsoToken token)
        {
            return _internalLatestContacts.CharacterLabels(token);
        }

        public async Task<IList<V1ContactCharacterLabel>> CharacterLabelsAsync(SsoToken token)
        {
            return await _internalLatestContacts.CharacterLabelsAsync(token);
        }

        public PagedModel<V2ContactCorporation> Corporation(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return _internalLatestContacts.Corporation(token, corporationId, page);
        }

        public async Task<PagedModel<V2ContactCorporation>> CorporationAsync(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return await _internalLatestContacts.CorporationAsync(token, corporationId, page);
        }

        public IList<V1ContactCorporationLabel> CorporationLabels(SsoToken token, int corporationId)
        {
            return _internalLatestContacts.CorporationLabels(token, corporationId);
        }

        public async Task<IList<V1ContactCorporationLabel>> CorporationLabelsAsync(SsoToken token, int corporationId)
        {
            return await _internalLatestContacts.CorporationLabelsAsync(token, corporationId);
        }
    }
}
