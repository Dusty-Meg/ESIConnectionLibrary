using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestContractEndpoints : ILatestContractEndpoints
    {
        private readonly IInternalLatestContracts _internalLatestContracts;

        public LatestContractEndpoints(string userAgent)
        {
         _internalLatestContracts = new InternalLatestContracts(null, userAgent);   
        }

        public PagedModel<V1ContractsCharacterContracts> GetCharactersContracts(SsoToken token, int characterId, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return _internalLatestContracts.GetCharactersContracts(token, characterId, page);
        }

        public async Task<PagedModel<V1ContractsCharacterContracts>> GetCharactersContractsAsync(SsoToken token, int characterId, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return await _internalLatestContracts.GetCharactersContractsAsync(token, characterId, page);
        }
    }
}
