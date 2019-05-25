using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestIndustryEndpoints : ILatestIndustryEndpoints
    {
        private readonly IInternalLatestIndustry _internalLatestIndustry;

        public LatestIndustryEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestIndustry = new InternalLatestIndustry(null, userAgent, testing);
        }

        public IList<V1IndustryCharacter> Character(SsoToken token, bool includeCompletedJobs)
        {
            return _internalLatestIndustry.Character(token, includeCompletedJobs);
        }

        public async Task<IList<V1IndustryCharacter>> CharacterAsync(SsoToken token, bool includeCompletedJobs)
        {
            return await _internalLatestIndustry.CharacterAsync(token, includeCompletedJobs);
        }

        public IList<V1IndustryCharacterMining> CharacterMining(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestIndustry.CharacterMining(token, page);
        }

        public async Task<IList<V1IndustryCharacterMining>> CharacterMiningAsync(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestIndustry.CharacterMiningAsync(token, page);
        }

        public IList<V1IndustryCorporationExtractions> CorporationExtractions(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestIndustry.CorporationExtractions(token, corporationId, page);
        }

        public async Task<IList<V1IndustryCorporationExtractions>> CorporationExtractionsAsync(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestIndustry.CorporationExtractionsAsync(token, corporationId, page);
        }

        public IList<V1IndustryCorporationObservers> CorporationObservers(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestIndustry.CorporationObservers(token, corporationId, page);
        }

        public async Task<IList<V1IndustryCorporationObservers>> CorporationObserversAsync(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestIndustry.CorporationObserversAsync(token, corporationId, page);
        }

        public IList<V1IndustryCorporationObserver> CorporationObserver(SsoToken token, int corporationId, long observerId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestIndustry.CorporationObserver(token, corporationId, observerId, page);
        }

        public async Task<IList<V1IndustryCorporationObserver>> CorporationObserverAsync(SsoToken token, int corporationId, long observerId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestIndustry.CorporationObserverAsync(token, corporationId, observerId, page);
        }

        public IList<V1IndustryCorporation> Corporation(SsoToken token, int corporationId, bool includeCompleted, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestIndustry.Corporation(token, corporationId, includeCompleted, page);
        }

        public async Task<IList<V1IndustryCorporation>> CorporationAsync(SsoToken token, int corporationId, bool includeCompleted, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestIndustry.CorporationAsync(token, corporationId, includeCompleted, page);
        }

        public IList<V1IndustryFacility> Facilities()
        {
            return _internalLatestIndustry.Facilities();
        }

        public async Task<IList<V1IndustryFacility>> FacilitiesAsync()
        {
            return await _internalLatestIndustry.FacilitiesAsync();
        }

        public IList<V1IndustrySystem> Systems()
        {
            return _internalLatestIndustry.Systems();
        }

        public async Task<IList<V1IndustrySystem>> SystemsAsync()
        {
            return await _internalLatestIndustry.SystemsAsync();
        }
    }
}
