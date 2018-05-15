using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestPlanetaryInteraction
    {
        V3PlanetaryInteractionCharactersPlanet GetCharacterPlanet(SsoToken token, int planetId);
        Task<V3PlanetaryInteractionCharactersPlanet> GetCharacterPlanetAsync(SsoToken token, int planetId);
        IList<V1PlanetaryInteractionCharactersPlanets> GetCharactersPlanets(SsoToken token);
        Task<IList<V1PlanetaryInteractionCharactersPlanets>> GetCharactersPlanetsAsync(SsoToken token);
        PagedModel<V1PlanetaryInteractionCorporationCustomsOffice> GetCorporationsCustomsOffices(SsoToken token, int corporationId, int page);
        Task<PagedModel<V1PlanetaryInteractionCorporationCustomsOffice>> GetCorporationsCustomsOfficesAsync(SsoToken token, int corporationId, int page);
        V1PlanetaryInteractionSchematic GetSchematic(int schematicId);
        Task<V1PlanetaryInteractionSchematic> GetSchematicAsync(int schematicId);
    }
}