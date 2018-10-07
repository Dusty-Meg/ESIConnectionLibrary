using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestFittings
    {
        IList<V1FittingsCharacter> Character(SsoToken token);
        void CharacterAddUpdate(SsoToken token, V1FittingsCharacterSave fitting);
        Task CharacterAddUpdateAsync(SsoToken token, V1FittingsCharacterSave fitting);
        Task<IList<V1FittingsCharacter>> CharacterAsync(SsoToken token);
        void CharacterDelete(SsoToken token, int fittingId);
        Task CharacterDeleteAsync(SsoToken token, int fittingId);
    }
}