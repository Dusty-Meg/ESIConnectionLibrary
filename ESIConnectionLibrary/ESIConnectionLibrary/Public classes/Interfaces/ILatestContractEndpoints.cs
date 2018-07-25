using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestContractEndpoints
    {
        PagedModel<V1ContractsCharacter> Character(SsoToken token, int page);
        Task<PagedModel<V1ContractsCharacter>> CharacterAsync(SsoToken token, int page);
        IList<V1ContractsCharacterBids> CharacterBids(SsoToken token, int contractId);
        Task<IList<V1ContractsCharacterBids>> CharacterBidsAsync(SsoToken token, int contractId);
        IList<V1ContractsCharacterItems> CharacterItems(SsoToken token, int contractId);
        Task<IList<V1ContractsCharacterItems>> CharacterItemsAsync(SsoToken token, int contractId);
        PagedModel<V1ContractsCorporation> Corporation(SsoToken token, int corporationId, int page);
        Task<PagedModel<V1ContractsCorporation>> CorporationAsync(SsoToken token, int corporationId, int page);
        IList<V1ContractsCorporationBids> CorporationBids(SsoToken token, int corporationId, int contractId);
        Task<IList<V1ContractsCorporationBids>> CorporationBidsAsync(SsoToken token, int corporationId, int contractId);
        IList<V1ContractsCorporationItems> CorporationItems(SsoToken token, int corporationId, int contractId);
        Task<IList<V1ContractsCorporationItems>> CorporationItemsAsync(SsoToken token, int corporationId, int contractId);
    }
}