using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalIndustry
    {
        IList<CharacterIndustryJob> GetCharactersIndustryJobs(SsoToken token, bool includeCompletedJobs);
        Task<IList<CharacterIndustryJob>> GetCharactersIndustryJobsAsync(SsoToken token, bool includeCompletedJobs);
    }
}