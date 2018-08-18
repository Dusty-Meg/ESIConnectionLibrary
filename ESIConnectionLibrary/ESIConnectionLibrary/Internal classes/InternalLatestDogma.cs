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
    internal class InternalLatestDogma : IInternalLatestDogma
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestDogma(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DogmaMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        private int SecondsToDT()
        {
            DateTime now = DateTime.Now;

            DateTime todaysDt = new DateTime(now.Year, now.Month, now.Day, 11, 5, 0);

            if ((todaysDt - now).TotalSeconds < 0)
            {
                return (int)(todaysDt.AddDays(1) - now).TotalSeconds;
            }

            return (int)(todaysDt - now).TotalSeconds;
        }

        public IList<int> Attributes()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.DogmaV1Attributes(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> AttributesAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.DogmaV1Attributes(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public V1DogmaAttribute Attribute(int attributeId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.DogmaV1Attribute(attributeId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1DogmaAttribute esiModel = JsonConvert.DeserializeObject<EsiV1DogmaAttribute>(esiRaw.Model);

            return _mapper.Map<EsiV1DogmaAttribute, V1DogmaAttribute>(esiModel);
        }

        public async Task<V1DogmaAttribute> AttributeAsync(int attributeId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.DogmaV1Attribute(attributeId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1DogmaAttribute esiModel = JsonConvert.DeserializeObject<EsiV1DogmaAttribute>(esiRaw.Model);

            return _mapper.Map<EsiV1DogmaAttribute, V1DogmaAttribute>(esiModel);
        }

        public V1DogmaDynamicItem DynamicItem(int typeId, long itemId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.DogmaV1DynamicItem(typeId, itemId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1DogmaDynamicItem esiModel = JsonConvert.DeserializeObject<EsiV1DogmaDynamicItem>(esiRaw.Model);

            return _mapper.Map<EsiV1DogmaDynamicItem, V1DogmaDynamicItem>(esiModel);
        }

        public async Task<V1DogmaDynamicItem> DynamicItemAsync(int typeId, long itemId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.DogmaV1DynamicItem(typeId, itemId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1DogmaDynamicItem esiModel = JsonConvert.DeserializeObject<EsiV1DogmaDynamicItem>(esiRaw.Model);

            return _mapper.Map<EsiV1DogmaDynamicItem, V1DogmaDynamicItem>(esiModel);
        }

        public IList<int> Effects()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.DogmaV1Effects(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> EffectsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.DogmaV1Effects(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public V2DogmaEffect Effect(int effectId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.DogmaV2Effect(effectId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV2DogmaEffect esiModel = JsonConvert.DeserializeObject<EsiV2DogmaEffect>(esiRaw.Model);

            return _mapper.Map<EsiV2DogmaEffect, V2DogmaEffect>(esiModel);
        }

        public async Task<V2DogmaEffect> EffectAsync(int effectId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.DogmaV2Effect(effectId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV2DogmaEffect esiModel = JsonConvert.DeserializeObject<EsiV2DogmaEffect>(esiRaw.Model);

            return _mapper.Map<EsiV2DogmaEffect, V2DogmaEffect>(esiModel);
        }
    }
}
