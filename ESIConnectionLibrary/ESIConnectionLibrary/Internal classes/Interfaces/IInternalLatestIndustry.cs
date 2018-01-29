using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestIndustry
    {
        IList<V1CharacterIndustryJob> GetCharactersIndustryJobs(SsoToken token, bool includeCompletedJobs);
        Task<IList<V1CharacterIndustryJob>> GetCharactersIndustryJobsAsync(SsoToken token, bool includeCompletedJobs);
    }
}