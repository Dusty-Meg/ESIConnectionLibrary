using System.Collections.Generic;
using System.Threading.Tasks;
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

        public IList<V1CharacterIndustryJob> GetCharacterIndustryJobs(SsoToken token, bool includeCompletedJobs)
        {
            return _internalLatestIndustry.GetCharactersIndustryJobs(token, includeCompletedJobs);
        }

        public async Task<IList<V1CharacterIndustryJob>> GetCharacterIndustryJobsAsync(SsoToken token, bool includeCompletedJobs)
        {
            return await _internalLatestIndustry.GetCharactersIndustryJobsAsync(token, includeCompletedJobs);
        }
    }
}
