using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestCloneEndpoints : ILatestCloneEndpoints
    {
        private readonly IInternalLatestClones _internalLatestClones;

        public LatestCloneEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestClones = new InternalLatestClones(null, userAgent, testing);
        }

        public V3CharactersClones GetCharactersClones(SsoToken token)
        {
            return _internalLatestClones.GetCharactersClones(token);
        }

        public async Task<V3CharactersClones> GetCharactersClonesAsync(SsoToken token)
        {
            return await _internalLatestClones.GetCharactersClonesAsync(token);
        }

        public IList<int> GetCharactersActiveImplants(SsoToken token)
        {
            return _internalLatestClones.GetCharactersActiveImplants(token);
        }

        public async Task<IList<int>> GetCharactersActiveImplantsAsync(SsoToken token)
        {
            return await _internalLatestClones.GetCharactersActiveImplantsAsync(token);
        }
    }
}
