using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestMail : IInternalLatestMail
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestMail(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public PagedModel<V1MailCharacter> Character(SsoToken token, int lastMailId)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_read_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1Character(token.CharacterId, lastMailId), _testing);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 30));

            IList<EsiV1MailCharacter> esiMail = JsonConvert.DeserializeObject<IList<EsiV1MailCharacter>>(raw.Model);

            IList<V1MailCharacter> mapped = _mapper.Map<IList<EsiV1MailCharacter>, IList<V1MailCharacter>>(esiMail);

            return new PagedModel<V1MailCharacter> {Model = mapped, CurrentPage = lastMailId};
        }

        public async Task<PagedModel<V1MailCharacter>> CharacterAsync(SsoToken token, int lastMailId)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_read_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1Character(token.CharacterId, lastMailId), _testing);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 30));

            IList<EsiV1MailCharacter> esiMail = JsonConvert.DeserializeObject<IList<EsiV1MailCharacter>>(raw.Model);

            IList<V1MailCharacter> mapped = _mapper.Map<IList<EsiV1MailCharacter>, IList<V1MailCharacter>>(esiMail);

            return new PagedModel<V1MailCharacter> { Model = mapped, CurrentPage = lastMailId };
        }

        public V1MailMail Mail(SsoToken token, int mailId)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_read_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1Mail(token.CharacterId, mailId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 30));

            EsiV1MailMail esiMail = JsonConvert.DeserializeObject<EsiV1MailMail>(esiRaw.Model);

            return _mapper.Map<EsiV1MailMail, V1MailMail>(esiMail);
        }

        public async Task<V1MailMail> MailAsync(SsoToken token, int mailId)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_read_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1Mail(token.CharacterId, mailId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 30));

            EsiV1MailMail esiMail = JsonConvert.DeserializeObject<EsiV1MailMail>(esiRaw.Model);

            return _mapper.Map<EsiV1MailMail, V1MailMail>(esiMail);
        }
    }
}
