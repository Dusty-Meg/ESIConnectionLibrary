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

        public IList<V1PlanetaryInteractionCharactersPlanets> CharactersPlanets(SsoToken token)
        {
            return _internalLatestPlanetaryInteraction.CharactersPlanets(token);
        }

        public async Task<IList<V1PlanetaryInteractionCharactersPlanets>> CharactersPlanetsAsync(SsoToken token)
        {
            return await _internalLatestPlanetaryInteraction.CharactersPlanetsAsync(token);
        }

        public V3PlanetaryInteractionCharactersPlanet CharacterPlanet(SsoToken token, int planetId)
        {
            return _internalLatestPlanetaryInteraction.CharacterPlanet(token, planetId);
        }

        public async Task<V3PlanetaryInteractionCharactersPlanet> CharacterPlanetAsync(SsoToken token, int planetId)
        {
            return await _internalLatestPlanetaryInteraction.CharacterPlanetAsync(token, planetId);
        }

        public PagedModel<V1PlanetaryInteractionCorporationCustomsOffice> CorporationsCustomsOffices(SsoToken token, int corporationId, int page)
        {
            return _internalLatestPlanetaryInteraction.CorporationsCustomsOffices(token, corporationId, page);
        }

        public async Task<PagedModel<V1PlanetaryInteractionCorporationCustomsOffice>> CorporationsCustomsOfficesAsync(SsoToken token, int corporationId, int page)
        {
            return await _internalLatestPlanetaryInteraction.CorporationsCustomsOfficesAsync(token, corporationId, page);
        }

        public V1PlanetaryInteractionSchematic Schematic(int schematicId)
        {
            return _internalLatestPlanetaryInteraction.Schematic(schematicId);
        }

        public async Task<V1PlanetaryInteractionSchematic> SchematicAsync(int schematicId)
        {
            return await _internalLatestPlanetaryInteraction.SchematicAsync(schematicId);
        }
    }
}
