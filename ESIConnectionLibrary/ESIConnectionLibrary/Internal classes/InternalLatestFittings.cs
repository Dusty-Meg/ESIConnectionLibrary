using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestFittings : IInternalLatestFittings
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestFittings(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<V1FittingsCharacter> Character(SsoToken token)
        {
            StaticMethods.CheckToken(token, FittingScopes.esi_fittings_read_fittings_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FittingsV1CharacterGet(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1FittingsCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV1FittingsCharacter>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1FittingsCharacter>, IList<V1FittingsCharacter>>(esiModel);
        }

        public async Task<IList<V1FittingsCharacter>> CharacterAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, FittingScopes.esi_fittings_read_fittings_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FittingsV1CharacterGet(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1FittingsCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV1FittingsCharacter>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1FittingsCharacter>, IList<V1FittingsCharacter>>(esiModel);
        }

        public void CharacterAddUpdate(SsoToken token, V1FittingsCharacterSave fitting)
        {
            StaticMethods.CheckToken(token, FittingScopes.esi_fittings_write_fittings_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FittingsV1CharacterUpdate(token.CharacterId), _testing);

            EsiV1FittingsCharacterSave model = _mapper.Map<EsiV1FittingsCharacterSave>(fitting);

            string objectModel = JsonConvert.SerializeObject(model);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, objectModel));
        }

        public async Task CharacterAddUpdateAsync(SsoToken token, V1FittingsCharacterSave fitting)
        {
            StaticMethods.CheckToken(token, FittingScopes.esi_fittings_write_fittings_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FittingsV1CharacterUpdate(token.CharacterId), _testing);

            EsiV1FittingsCharacterSave model = _mapper.Map<EsiV1FittingsCharacterSave>(fitting);

            string objectModel = JsonConvert.SerializeObject(model);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, objectModel));
        }

        public void CharacterDelete(SsoToken token, int fittingId)
        {
            StaticMethods.CheckToken(token, FittingScopes.esi_fittings_write_fittings_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FittingsV1CharacterDelete(token.CharacterId, fittingId), _testing);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Delete(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public async Task CharacterDeleteAsync(SsoToken token, int fittingId)
        {
            StaticMethods.CheckToken(token, FittingScopes.esi_fittings_write_fittings_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FittingsV1CharacterDelete(token.CharacterId, fittingId), _testing);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.DeleteAsync(StaticMethods.CreateHeaders(token), url, string.Empty));
        }
    }
}
