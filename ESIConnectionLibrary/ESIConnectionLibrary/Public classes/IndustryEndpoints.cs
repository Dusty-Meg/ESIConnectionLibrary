using System.Collections.Generic;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class IndustryEndpoints : IIndustryEndpoints
    {
        private readonly IInternalIndustry _internalIndustry;

        public IndustryEndpoints()
        {
            _internalIndustry = new InternalIndustry(null);
        }

        public IList<CharacterIndustryJob> GetCharacterIndustryJobs(SsoToken token, bool includeCompletedJobs)
        {
            return _internalIndustry.GetChractersIndustryJobs(token, includeCompletedJobs);
        }
    }
}
