using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestUniverse : IInternalLatestUniverse
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestUniverse(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UniverseNamesMappings>();
                cfg.AddProfile<UniverseGetTypeMappings>();
                cfg.AddProfile<UniverseGetTypeDogmaAttributeMappings>();
                cfg.AddProfile<UniverseGetTypeDogmaEffectMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        private int SecondsToDT()
        {
            DateTime now = DateTime.Now;

            DateTime todaysDT = new DateTime(now.Year, now.Month, now.Day, 11, 5, 0);

            if ((todaysDT - now).TotalSeconds < 0)
            {
                return (int)(todaysDT.AddDays(1) - now).TotalSeconds;
            }

            return (int) (todaysDT - now).TotalSeconds;
        }

        public IList<V2UniverseNames> GetNames(IList<int> ids)
        {
            string url = StaticConnectionStrings.UniverseNames();

            string jsonObject = JsonConvert.SerializeObject(ids);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(), url, jsonObject, SecondsToDT()));

            IList<EsiV2UniverseNames> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV2UniverseNames>>(esiRaw);

            return _mapper.Map<IList<EsiV2UniverseNames>, IList<V2UniverseNames>>(esiUniverseNames);
        }

        public async Task<IList<V2UniverseNames>> GetNamesAsync(IList<int> ids)
        {
            string url = StaticConnectionStrings.UniverseNames();

            string jsonObject = JsonConvert.SerializeObject(ids);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(), url, jsonObject, SecondsToDT()));

            IList<EsiV2UniverseNames> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV2UniverseNames>>(esiRaw);

            return _mapper.Map<IList<EsiV2UniverseNames>, IList<V2UniverseNames>>(esiUniverseNames);
        }

        public V3UniverseGetType GetType(long id)
        {
            string url = StaticConnectionStrings.UniverseGetType(id);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV3UniverseGetType esiV3UniverseGetType = JsonConvert.DeserializeObject<EsiV3UniverseGetType>(esiRaw);

            return _mapper.Map<EsiV3UniverseGetType, V3UniverseGetType>(esiV3UniverseGetType);
        }

        public async Task<V3UniverseGetType> GetTypeAsync(long id)
        {
            string url = StaticConnectionStrings.UniverseGetType(id);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV3UniverseGetType esiV3UniverseGetType = JsonConvert.DeserializeObject<EsiV3UniverseGetType>(esiRaw);

            return _mapper.Map<EsiV3UniverseGetType, V3UniverseGetType>(esiV3UniverseGetType);
        }
    }
}
