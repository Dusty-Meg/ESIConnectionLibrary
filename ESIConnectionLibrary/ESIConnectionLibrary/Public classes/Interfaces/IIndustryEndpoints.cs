using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface IIndustryEndpoints
    {
        IList<CharacterIndustryJob> GetCharacterIndustryJobs(SsoToken token, bool includeCompletedJobs);
    }
}