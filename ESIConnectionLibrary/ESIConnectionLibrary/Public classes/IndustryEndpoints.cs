using System.Collections.Generic;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class IndustryEndpoints : IIndustryEndpoints
    {
        private readonly IInternalIndustry _internalIndustry;

        public IndustryEndpoints(string userAgent)
        {
            _internalIndustry = new InternalIndustry(null, userAgent);
        }

        public IList<CharacterIndustryJob> GetCharacterIndustryJobs(SsoToken token, bool includeCompletedJobs)
        {
            return _internalIndustry.GetCharactersIndustryJobs(token, includeCompletedJobs);
        }
    }
}
