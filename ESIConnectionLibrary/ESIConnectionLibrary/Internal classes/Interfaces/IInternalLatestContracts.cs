using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestContracts
    {
        PagedModel<V1ContractsCharacterContracts> GetCharactersContracts(SsoToken token, int page);
        Task<PagedModel<V1ContractsCharacterContracts>> GetCharactersContractsAsync(SsoToken token, int page);
    }
}