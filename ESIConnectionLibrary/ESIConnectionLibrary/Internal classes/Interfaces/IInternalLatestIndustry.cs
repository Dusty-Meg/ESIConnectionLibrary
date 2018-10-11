using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestIndustry
    {
        IList<V1IndustryCharacter> Character(SsoToken token, bool includeCompletedJobs);
        Task<IList<V1IndustryCharacter>> CharacterAsync(SsoToken token, bool includeCompletedJobs);
        IList<V1IndustryCharacterMining> CharacterMining(SsoToken token, int page);
        Task<IList<V1IndustryCharacterMining>> CharacterMiningAsync(SsoToken token, int page);
        IList<V1IndustryCorporation> Corporation(SsoToken token, int corporationId, bool includeCompleted, int page);
        Task<IList<V1IndustryCorporation>> CorporationAsync(SsoToken token, int corporationId, bool includeCompleted, int page);
        IList<V1IndustryCorporationExtractions> CorporationExtractions(SsoToken token, int corporationId, int page);
        Task<IList<V1IndustryCorporationExtractions>> CorporationExtractionsAsync(SsoToken token, int corporationId, int page);
        IList<V1IndustryCorporationObserver> CorporationObserver(SsoToken token, int corporationId, long observerId, int page);
        Task<IList<V1IndustryCorporationObserver>> CorporationObserverAsync(SsoToken token, int corporationId, long observerId, int page);
        IList<V1IndustryCorporationObservers> CorporationObservers(SsoToken token, int corporationId, int page);
        Task<IList<V1IndustryCorporationObservers>> CorporationObserversAsync(SsoToken token, int corporationId, int page);
        IList<V1IndustryFacility> Facilities();
        Task<IList<V1IndustryFacility>> FacilitiesAsync();
        IList<V1IndustrySystem> Systems();
        Task<IList<V1IndustrySystem>> SystemsAsync();
    }
}