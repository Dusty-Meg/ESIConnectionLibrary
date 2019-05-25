using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestFittingsEndpoints : ILatestFittingsEndpoints
    {
        private readonly IInternalLatestFittings _internalLatestFittings;

        public LatestFittingsEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestFittings = new InternalLatestFittings(null, userAgent, testing);
        }

        public IList<V2FittingsCharacter> Character(SsoToken token)
        {
            return _internalLatestFittings.Character(token);
        }

        public async Task<IList<V2FittingsCharacter>> CharacterAsync(SsoToken token)
        {
            return await _internalLatestFittings.CharacterAsync(token);
        }

        public void CharacterAddUpdate(SsoToken token, V2FittingsCharacterSave fitting)
        {
            _internalLatestFittings.CharacterAddUpdate(token, fitting);
        }

        public async Task CharacterAddUpdateAsync(SsoToken token, V2FittingsCharacterSave fitting)
        {
            await _internalLatestFittings.CharacterAddUpdateAsync(token, fitting);
        }

        public void CharacterDelete(SsoToken token, int fittingId)
        {
            _internalLatestFittings.CharacterDelete(token, fittingId);
        }

        public async Task CharacterDeleteAsync(SsoToken token, int fittingId)
        {
            await _internalLatestFittings.CharacterDeleteAsync(token, fittingId);
        }
    }
}
