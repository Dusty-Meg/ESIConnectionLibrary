using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestContractEndpoints
    {
        PagedModel<V1ContractsCharacterContracts> GetCharactersContracts(SsoToken token, int characterId, int page);
        Task<PagedModel<V1ContractsCharacterContracts>> GetCharactersContractsAsync(SsoToken token, int characterId, int page);
    }
}