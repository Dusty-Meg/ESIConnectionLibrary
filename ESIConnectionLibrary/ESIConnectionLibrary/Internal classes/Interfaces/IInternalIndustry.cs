using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalIndustry
    {
        IList<CharacterIndustryJob> GetCharactersIndustryJobs(SsoToken token, bool includeCompletedJobs);
    }
}