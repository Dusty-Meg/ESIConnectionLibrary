﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestFittingsEndpoints
    {
        IList<V2FittingsCharacter> Character(SsoToken token);
        void CharacterAddUpdate(SsoToken token, V2FittingsCharacterSave fitting);
        Task CharacterAddUpdateAsync(SsoToken token, V2FittingsCharacterSave fitting);
        Task<IList<V2FittingsCharacter>> CharacterAsync(SsoToken token);
        void CharacterDelete(SsoToken token, int fittingId);
        Task CharacterDeleteAsync(SsoToken token, int fittingId);
    }
}