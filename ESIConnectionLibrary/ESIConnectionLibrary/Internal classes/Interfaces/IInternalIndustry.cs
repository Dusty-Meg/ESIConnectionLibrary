using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalIndustry
    {
        IList<CharacterIndustryJob> GetChractersIndustryJobs(SsoToken token, bool includeCompletedJobs);
    }
}