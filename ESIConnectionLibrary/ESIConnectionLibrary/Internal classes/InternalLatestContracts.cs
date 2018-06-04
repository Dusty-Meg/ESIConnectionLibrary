﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestContracts : IInternalLatestContracts
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestContracts(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ContractMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public PagedModel<V1ContractsCharacterContracts> GetCharactersContracts(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_character_contracts_v1);

            string url = StaticConnectionStrings.ContractsV1GetCharactersContracts(token.CharacterId, page);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContractsCharacterContracts> esiV1ContractsCharacter = JsonConvert.DeserializeObject<IList<EsiV1ContractsCharacterContracts>>(raw.Model);

            IList<V1ContractsCharacterContracts> mapped = _mapper.Map<IList<EsiV1ContractsCharacterContracts>, IList<V1ContractsCharacterContracts>>(esiV1ContractsCharacter);

            return new PagedModel<V1ContractsCharacterContracts> {Model = mapped, MaxPages = raw.MaxPages, CurrentPage = page};
        }

        public async Task<PagedModel<V1ContractsCharacterContracts>> GetCharactersContractsAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_character_contracts_v1);

            string url = StaticConnectionStrings.ContractsV1GetCharactersContracts(token.CharacterId, page);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContractsCharacterContracts> esiV1ContractsCharacter = JsonConvert.DeserializeObject<IList<EsiV1ContractsCharacterContracts>>(raw.Model);

            IList<V1ContractsCharacterContracts> mapped = _mapper.Map<IList<EsiV1ContractsCharacterContracts>, IList<V1ContractsCharacterContracts>>(esiV1ContractsCharacter);

            return new PagedModel<V1ContractsCharacterContracts> { Model = mapped, MaxPages = raw.MaxPages, CurrentPage = page };
        }
    }
}
