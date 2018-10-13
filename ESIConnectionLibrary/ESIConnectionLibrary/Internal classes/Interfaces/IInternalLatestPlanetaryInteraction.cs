using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestPlanetaryInteraction
    {
        V3PlanetaryInteractionCharactersPlanet CharacterPlanet(SsoToken token, int planetId);
        Task<V3PlanetaryInteractionCharactersPlanet> CharacterPlanetAsync(SsoToken token, int planetId);
        IList<V1PlanetaryInteractionCharactersPlanets> CharactersPlanets(SsoToken token);
        Task<IList<V1PlanetaryInteractionCharactersPlanets>> CharactersPlanetsAsync(SsoToken token);
        PagedModel<V1PlanetaryInteractionCorporationCustomsOffice> CorporationsCustomsOffices(SsoToken token, int corporationId, int page);
        Task<PagedModel<V1PlanetaryInteractionCorporationCustomsOffice>> CorporationsCustomsOfficesAsync(SsoToken token, int corporationId, int page);
        V1PlanetaryInteractionSchematic Schematic(int schematicId);
        Task<V1PlanetaryInteractionSchematic> SchematicAsync(int schematicId);
    }
}