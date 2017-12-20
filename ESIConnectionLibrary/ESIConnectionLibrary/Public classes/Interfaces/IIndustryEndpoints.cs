using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface IIndustryEndpoints
    {
        IList<CharacterIndustryJob> GetCharacterIndustryJobs(SsoToken token, bool includeCompletedJobs);
        Task<IList<CharacterIndustryJob>> GetCharacterIndustryJobsAsync(SsoToken token, bool includeCompletedJobs);
    }
}