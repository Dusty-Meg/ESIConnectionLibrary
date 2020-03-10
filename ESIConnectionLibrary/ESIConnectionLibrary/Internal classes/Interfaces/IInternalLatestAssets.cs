﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestAssets
    {
        PagedModel<V4AssetsCharacter> Characters(SsoToken token, int page);
        Task<PagedModel<V4AssetsCharacter>> CharactersAsync(SsoToken token, int page);
        IList<V2AssetsCharacterLocation> CharacterLocations(SsoToken token, IList<long> ids);
        Task<IList<V2AssetsCharacterLocation>> CharacterLocationAsync(SsoToken token, IList<long> ids);
        IList<V1AssetsCharacterName> CharacterNames(SsoToken token, IList<long> ids);
        Task<IList<V1AssetsCharacterName>> CharacterNamesAsync(SsoToken token, IList<long> ids);
        PagedModel<V4AssetsCorporations> Corporations(SsoToken token, int corporationId, int page);
        Task<PagedModel<V4AssetsCorporations>> CorporationsAsync(SsoToken token, int corporationId, int page);
        IList<V2AssetsCorporationLocation> CorporationLocations(SsoToken token, int corporationId, IList<long> ids);
        Task<IList<V2AssetsCorporationLocation>> CorporationLocationsAsync(SsoToken token, int corporationId, IList<long> ids);
        IList<V1AssetsCorporationName> CorporationNames(SsoToken token, int corporationId, IList<long> ids);
        Task<IList<V1AssetsCorporationName>> CorporationNamesAsync(SsoToken token, int corporationId, IList<long> ids);
    }
}