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

        public PagedModel<V1MailGetCharactersMail> GetCharactersMail(SsoToken token, int lastMailId)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_read_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1MailGetCharactersMail(token.CharacterId, lastMailId), _testing);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 30));

            IList<EsiV1MailGetCharactersMail> esiMail = JsonConvert.DeserializeObject<IList<EsiV1MailGetCharactersMail>>(raw.Model);

            IList<V1MailGetCharactersMail> mapped = _mapper.Map<IList<EsiV1MailGetCharactersMail>, IList<V1MailGetCharactersMail>>(esiMail);

            return new PagedModel<V1MailGetCharactersMail> {Model = mapped, CurrentPage = lastMailId};
        }

        public async Task<PagedModel<V1MailGetCharactersMail>> GetCharactersMailAsync(SsoToken token, int lastMailId)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_read_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1MailGetCharactersMail(token.CharacterId, lastMailId), _testing);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 30));

            IList<EsiV1MailGetCharactersMail> esiMail = JsonConvert.DeserializeObject<IList<EsiV1MailGetCharactersMail>>(raw.Model);

            IList<V1MailGetCharactersMail> mapped = _mapper.Map<IList<EsiV1MailGetCharactersMail>, IList<V1MailGetCharactersMail>>(esiMail);

            return new PagedModel<V1MailGetCharactersMail> { Model = mapped, CurrentPage = lastMailId };
        }

        public V1MailGetMail GetMail(SsoToken token, int mailId)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_read_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1MailGetMail(token.CharacterId, mailId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 30));

            EsiV1MailGetMail esiGetMail = JsonConvert.DeserializeObject<EsiV1MailGetMail>(esiRaw.Model);

            return _mapper.Map<EsiV1MailGetMail, V1MailGetMail>(esiGetMail);
        }

        public async Task<V1MailGetMail> GetMailAsync(SsoToken token, int mailId)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_read_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1MailGetMail(token.CharacterId, mailId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 30));

            EsiV1MailGetMail esiGetMail = JsonConvert.DeserializeObject<EsiV1MailGetMail>(esiRaw.Model);

            return _mapper.Map<EsiV1MailGetMail, V1MailGetMail>(esiGetMail);
        }
    }
}
