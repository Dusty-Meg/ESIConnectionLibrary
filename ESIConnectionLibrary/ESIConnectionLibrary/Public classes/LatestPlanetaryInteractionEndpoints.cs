using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestPlanetaryInteractionEndpoints : ILatestPlanetaryInteractionEndpoints
    {
        private readonly IInternalLatestPlanetaryInteraction _internalLatestPlanetaryInteraction;

        public LatestPlanetaryInteractionEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestPlanetaryInteraction = new InternalLatestPlanetaryInteraction(null, userAgent, testing);
        }

        public IList<V1PlanetaryInteractionCharactersPlanets> GetCharactersPlanets(SsoToken token)
        {
            return _internalLatestPlanetaryInteraction.GetCharactersPlanets(token);
        }

        public async Task<IList<V1PlanetaryInteractionCharactersPlanets>> GetCharactersPlanetsAsync(SsoToken token)
        {
            return await _internalLatestPlanetaryInteraction.GetCharactersPlanetsAsync(token);
        }

        public V3PlanetaryInteractionCharactersPlanet GetCharacterPlanet(SsoToken token, int planetId)
        {
            return _internalLatestPlanetaryInteraction.GetCharacterPlanet(token, planetId);
        }

        public async Task<V3PlanetaryInteractionCharactersPlanet> GetCharacterPlanetAsync(SsoToken token, int planetId)
        {
            return await _internalLatestPlanetaryInteraction.GetCharacterPlanetAsync(token, planetId);
        }

        public PagedModel<V1PlanetaryInteractionCorporationCustomsOffice> GetCorporationsCustomsOffices(SsoToken token, int corporationId, int page)
        {
            return _internalLatestPlanetaryInteraction.GetCorporationsCustomsOffices(token, corporationId, page);
        }

        public async Task<PagedModel<V1PlanetaryInteractionCorporationCustomsOffice>> GetCorporationsCustomsOfficesAsync(SsoToken token, int corporationId, int page)
        {
            return await _internalLatestPlanetaryInteraction.GetCorporationsCustomsOfficesAsync(token, corporationId, page);
        }

        public V1PlanetaryInteractionSchematic GetSchematic(int schematicId)
        {
            return _internalLatestPlanetaryInteraction.GetSchematic(schematicId);
        }

        public async Task<V1PlanetaryInteractionSchematic> GetSchematicAsync(int schematicId)
        {
            return await _internalLatestPlanetaryInteraction.GetSchematicAsync(schematicId);
        }
    }
}
