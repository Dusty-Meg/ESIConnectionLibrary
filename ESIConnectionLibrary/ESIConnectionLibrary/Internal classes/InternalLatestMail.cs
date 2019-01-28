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

        public void Send(SsoToken token, V1MailSend mail)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_send_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1Send(token.CharacterId), _testing);

            EsiV1MailSend model = _mapper.Map<EsiV1MailSend>(mail);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, JsonConvert.SerializeObject(model)));
        }

        public async Task SendAsync(SsoToken token, V1MailSend mail)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_send_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1Send(token.CharacterId), _testing);

            EsiV1MailSend model = _mapper.Map<EsiV1MailSend>(mail);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, JsonConvert.SerializeObject(model)));
        }

        public void Delete(SsoToken token, int mailId)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_organize_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1Delete(token.CharacterId, mailId), _testing);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Delete(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public async Task DeleteAsync(SsoToken token, int mailId)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_organize_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1Delete(token.CharacterId, mailId), _testing);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.DeleteAsync(StaticMethods.CreateHeaders(token), url, string.Empty));
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

        public void Metadata(SsoToken token, int mailId, V1MailMetadata metadata)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_organize_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1Metadata(token.CharacterId, mailId), _testing);

            EsiV1MailMetadata model = _mapper.Map<EsiV1MailMetadata>(metadata);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Put(StaticMethods.CreateHeaders(token), url, JsonConvert.SerializeObject(model)));
        }

        public async Task MetadataAsync(SsoToken token, int mailId, V1MailMetadata metadata)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_organize_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1Metadata(token.CharacterId, mailId), _testing);

            EsiV1MailMetadata model = _mapper.Map<EsiV1MailMetadata>(metadata);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PutAsync(StaticMethods.CreateHeaders(token), url, JsonConvert.SerializeObject(model)));
        }

        public V3MailLabelsAndUnreadCount LabelsAndUnreadCount(SsoToken token)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_read_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV3LabelsAndUnreadCount(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 30));

            EsiV3MailLabelsAndUnreadCount esiMail = JsonConvert.DeserializeObject<EsiV3MailLabelsAndUnreadCount>(esiRaw.Model);

            return _mapper.Map<EsiV3MailLabelsAndUnreadCount, V3MailLabelsAndUnreadCount>(esiMail);
        }

        public async Task<V3MailLabelsAndUnreadCount> LabelsAndUnreadCountAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_read_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV3LabelsAndUnreadCount(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 30));

            EsiV3MailLabelsAndUnreadCount esiMail = JsonConvert.DeserializeObject<EsiV3MailLabelsAndUnreadCount>(esiRaw.Model);

            return _mapper.Map<EsiV3MailLabelsAndUnreadCount, V3MailLabelsAndUnreadCount>(esiMail);
        }

        public void CreateLabel(SsoToken token, V2MailCreateLabel labelModel)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_organize_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV2CreateLabel(token.CharacterId), _testing);

            EsiV2MailCreateLabel model = _mapper.Map<EsiV2MailCreateLabel>(labelModel);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, JsonConvert.SerializeObject(model)));
        }

        public async Task CreateLabelAsync(SsoToken token, V2MailCreateLabel labelModel)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_organize_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV2CreateLabel(token.CharacterId), _testing);

            EsiV2MailCreateLabel model = _mapper.Map<EsiV2MailCreateLabel>(labelModel);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, JsonConvert.SerializeObject(model)));
        }

        public void DeleteLabel(SsoToken token, int labelId)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_organize_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1DeleteLabel(token.CharacterId, labelId), _testing);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Delete(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public async Task DeleteLabelAsync(SsoToken token, int labelId)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_organize_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1DeleteLabel(token.CharacterId, labelId), _testing);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async() => await _webClient.DeleteAsync(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public IList<V1MailMailingList> MailingLists(SsoToken token)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_read_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1MailingList(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            IList<EsiV1MailMailingList> esiMail = JsonConvert.DeserializeObject<IList<EsiV1MailMailingList>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1MailMailingList>, IList<V1MailMailingList>>(esiMail);
        }

        public async Task<IList<V1MailMailingList>> MailingListsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, MailScopes.esi_mail_read_mail_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MailV1MailingList(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 120));

            IList<EsiV1MailMailingList> esiMail = JsonConvert.DeserializeObject<IList<EsiV1MailMailingList>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1MailMailingList>, IList<V1MailMailingList>>(esiMail);
        }
    }
}
