using System.Collections.Generic;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalUniverse : IInternalUniverse
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalUniverse(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UniverseNamesMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public IList<UniverseNames> GetNames(IList<int> ids)
        {
            string url = StaticConnectionStrings.UniverseNames();

            string jsonObject = JsonConvert.SerializeObject(ids);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(), url, jsonObject));

            IList<EsiUniverseNames> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiUniverseNames>>(esiRaw);

            return _mapper.Map<IList<EsiUniverseNames>, IList<UniverseNames>>(esiUniverseNames);
        }
    }
}
