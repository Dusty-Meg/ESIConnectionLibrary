using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestContractEndpoints : ILatestContractEndpoints
    {
        private readonly IInternalLatestContracts _internalLatestContracts;

        public LatestContractEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestContracts = new InternalLatestContracts(null, userAgent, testing);   
        }

        public PagedModel<V1ContractsCharacter> Character(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestContracts.Character(token, page);
        }

        public async Task<PagedModel<V1ContractsCharacter>> CharacterAsync(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestContracts.CharacterAsync(token, page);
        }

        public IList<V1ContractsCharacterBids> CharacterBids(SsoToken token, int contractId)
        {
            return _internalLatestContracts.CharacterBids(token, contractId);
        }

        public async Task<IList<V1ContractsCharacterBids>> CharacterBidsAsync(SsoToken token, int contractId)
        {
            return await _internalLatestContracts.CharacterBidsAsync(token, contractId);
        }

        public IList<V1ContractsCharacterItems> CharacterItems(SsoToken token, int contractId)
        {
            return _internalLatestContracts.CharacterItems(token, contractId);
        }

        public async Task<IList<V1ContractsCharacterItems>> CharacterItemsAsync(SsoToken token, int contractId)
        {
            return await _internalLatestContracts.CharacterItemsAsync(token, contractId);
        }

        public PagedModel<V1ContractsCorporation> Corporation(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestContracts.Corporation(token, corporationId, page);
        }

        public async Task<PagedModel<V1ContractsCorporation>> CorporationAsync(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestContracts.CorporationAsync(token, corporationId, page);
        }

        public IList<V1ContractsCorporationBids> CorporationBids(SsoToken token, int corporationId, int contractId)
        {
            return _internalLatestContracts.CorporationBids(token, corporationId, contractId);
        }

        public async Task<IList<V1ContractsCorporationBids>> CorporationBidsAsync(SsoToken token, int corporationId, int contractId)
        {
            return await _internalLatestContracts.CorporationBidsAsync(token, corporationId, contractId);
        }

        public IList<V1ContractsCorporationItems> CorporationItems(SsoToken token, int corporationId, int contractId)
        {
            return _internalLatestContracts.CorporationItems(token, corporationId, contractId);
        }

        public async Task<IList<V1ContractsCorporationItems>> CorporationItemsAsync(SsoToken token, int corporationId, int contractId)
        {
            return await _internalLatestContracts.CorporationItemsAsync(token, corporationId, contractId);
        }

        public PagedModel<V1ContractsPublic> Public(int regionId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestContracts.Public(regionId, page);
        }

        public async Task<PagedModel<V1ContractsPublic>> PublicAsync(int regionId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestContracts.PublicAsync(regionId, page);
        }

        public PagedModel<V1ContractsPublicBid> PublicBids(int contractId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestContracts.PublicBids(contractId, page);
        }

        public async Task<PagedModel<V1ContractsPublicBid>> PublicBidsAsync(int contractId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestContracts.PublicBidsAsync(contractId, page);
        }

        public PagedModel<V1ContractsPublicItem> PublicItems(int contractId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestContracts.PublicItems(contractId, page);
        }

        public async Task<PagedModel<V1ContractsPublicItem>> PublicItemsAsync(int contractId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestContracts.PublicItemsAsync(contractId, page);
        }
    }
}
