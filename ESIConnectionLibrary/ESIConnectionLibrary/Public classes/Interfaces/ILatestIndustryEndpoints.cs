using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestIndustryEndpoints
    {
        IList<V1CharacterIndustryJob> GetCharacterIndustryJobs(SsoToken token, bool includeCompletedJobs);
        Task<IList<V1CharacterIndustryJob>> GetCharacterIndustryJobsAsync(SsoToken token, bool includeCompletedJobs);
    }
}