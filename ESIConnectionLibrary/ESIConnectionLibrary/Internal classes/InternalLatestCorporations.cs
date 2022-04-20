using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.Automapper_Profiles;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestCorporations : IInternalLatestCorporations
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestCorporations(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CorporationsProfile>();
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

        public V4CorporationPublicInfo PublicInfo(long corporationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV4PublicInfo(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV4CorporationPublicInfo esiModel = JsonConvert.DeserializeObject<EsiV4CorporationPublicInfo>(esiRaw.Model);

            return _mapper.Map<V4CorporationPublicInfo>(esiModel);
        }

        public async Task<V4CorporationPublicInfo> PublicInfoAsync(long corporationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV4PublicInfo(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV4CorporationPublicInfo esiModel = JsonConvert.DeserializeObject<EsiV4CorporationPublicInfo>(esiRaw.Model);

            return _mapper.Map<V4CorporationPublicInfo>(esiModel);
        }

        public IList<V3CorporationAllianceHistory> AllianceHistory(long corporationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV3AllianceHistory(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV3CorporationAllianceHistory> esiModel = JsonConvert.DeserializeObject<IList<EsiV3CorporationAllianceHistory>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV3CorporationAllianceHistory>, IList<V3CorporationAllianceHistory>>(esiModel);
        }

        public async Task<IList<V3CorporationAllianceHistory>> AllianceHistoryAsync(long corporationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV3AllianceHistory(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV3CorporationAllianceHistory> esiModel = JsonConvert.DeserializeObject<IList<EsiV3CorporationAllianceHistory>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV3CorporationAllianceHistory>, IList<V3CorporationAllianceHistory>>(esiModel);
        }

        public PagedModel<V3CorporationBlueprints> Blueprints(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_blueprints_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV3Bluepints(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3CorporationBlueprints> esiModel = JsonConvert.DeserializeObject<IList<EsiV3CorporationBlueprints>>(esiRaw.Model);

            IList<V3CorporationBlueprints> mapped = _mapper.Map<IList<EsiV3CorporationBlueprints>, IList<V3CorporationBlueprints>>(esiModel);

            return new PagedModel<V3CorporationBlueprints> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V3CorporationBlueprints>> BlueprintsAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_blueprints_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV3Bluepints(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3CorporationBlueprints> esiModel = JsonConvert.DeserializeObject<IList<EsiV3CorporationBlueprints>>(esiRaw.Model);

            IList<V3CorporationBlueprints> mapped = _mapper.Map<IList<EsiV3CorporationBlueprints>, IList<V3CorporationBlueprints>>(esiModel);

            return new PagedModel<V3CorporationBlueprints>{ Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public PagedModel<V3CorporationContainerLogs> ContainerLogs(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_container_logs_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV3ContainersLogs(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV3CorporationContainerLogs> esiModel = JsonConvert.DeserializeObject<IList<EsiV3CorporationContainerLogs>>(esiRaw.Model);

            IList<V3CorporationContainerLogs> mapped = _mapper.Map<IList<EsiV3CorporationContainerLogs>, IList<V3CorporationContainerLogs>>(esiModel);

            return new PagedModel<V3CorporationContainerLogs>{ Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V3CorporationContainerLogs>> ContainerLogsAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_container_logs_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV3ContainersLogs(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV3CorporationContainerLogs> esiModel = JsonConvert.DeserializeObject<IList<EsiV3CorporationContainerLogs>>(esiRaw.Model);

            IList<V3CorporationContainerLogs> mapped = _mapper.Map<IList<EsiV3CorporationContainerLogs>, IList<V3CorporationContainerLogs>>(esiModel);

            return new PagedModel<V3CorporationContainerLogs> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public V2CorporationDivisions Divisions(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_divisions_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2Divisions(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV2CorporationDivisions esiModel = JsonConvert.DeserializeObject<EsiV2CorporationDivisions>(esiRaw.Model);

            return _mapper.Map<V2CorporationDivisions>(esiModel);
        }

        public async Task<V2CorporationDivisions> DivisionsAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_divisions_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2Divisions(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV2CorporationDivisions esiModel = JsonConvert.DeserializeObject<EsiV2CorporationDivisions>(esiRaw.Model);

            return _mapper.Map<V2CorporationDivisions>(esiModel);
        }

        public IList<V1CorporationFacilities> Facilities(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_facilities_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Facilities(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationFacilities> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationFacilities>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationFacilities>, IList<V1CorporationFacilities>>(esiModel);
        }

        public async Task<IList<V1CorporationFacilities>> FacilitiesAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_facilities_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Facilities(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationFacilities> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationFacilities>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationFacilities>, IList<V1CorporationFacilities>>(esiModel);
        }

        public V2CorporationIcons Icons(long corporationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Icons(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV2CorporationIcons esiModel = JsonConvert.DeserializeObject<EsiV2CorporationIcons>(esiRaw.Model);

            return _mapper.Map<V2CorporationIcons>(esiModel);
        }

        public async Task<V2CorporationIcons> IconsAsync(long corporationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Icons(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV2CorporationIcons esiModel = JsonConvert.DeserializeObject<EsiV2CorporationIcons>(esiRaw.Model);

            return _mapper.Map<V2CorporationIcons>(esiModel);
        }

        public PagedModel<V2CorporationMedals> Medals(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_medals_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2Medals(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationMedals> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationMedals>>(esiRaw.Model);

            IList<V2CorporationMedals> mapped = _mapper.Map<IList<EsiV2CorporationMedals>, IList<V2CorporationMedals>>(esiModel);

            return new PagedModel<V2CorporationMedals>{ CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public async Task<PagedModel<V2CorporationMedals>> MedalsAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_medals_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2Medals(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationMedals> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationMedals>>(esiRaw.Model);

            IList<V2CorporationMedals> mapped = _mapper.Map<IList<EsiV2CorporationMedals>, IList<V2CorporationMedals>>(esiModel);

            return new PagedModel<V2CorporationMedals> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public PagedModel<V2CorporationMedalsIssued> IssuedMedals(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_medals_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2MedalsIssued(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationMedalsIssued> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationMedalsIssued>>(esiRaw.Model);

            IList<V2CorporationMedalsIssued> mapped = _mapper.Map<IList<EsiV2CorporationMedalsIssued>, IList<V2CorporationMedalsIssued>>(esiModel);

            return new PagedModel<V2CorporationMedalsIssued> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public async Task<PagedModel<V2CorporationMedalsIssued>> IssuedMedalsAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_medals_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2MedalsIssued(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationMedalsIssued> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationMedalsIssued>>(esiRaw.Model);

            IList<V2CorporationMedalsIssued> mapped = _mapper.Map<IList<EsiV2CorporationMedalsIssued>, IList<V2CorporationMedalsIssued>>(esiModel);

            return new PagedModel<V2CorporationMedalsIssued> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public IList<int> Members(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV4Members(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> MembersAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV4Members(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public int MembersLimit(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_track_members_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2MembersLimit(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            return JsonConvert.DeserializeObject<int>(esiRaw.Model);
        }

        public async Task<int> MembersLimitAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_track_members_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2MembersLimit(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            return JsonConvert.DeserializeObject<int>(esiRaw.Model);
        }

        public IList<V2CorporationMembersTitles> MembersTitles(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2CorporationMemberTitles(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationMembersTitles> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationMembersTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CorporationMembersTitles>, IList<V2CorporationMembersTitles>>(esiModel);
        }

        public async Task<IList<V2CorporationMembersTitles>> MembersTitlesAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2CorporationMemberTitles(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationMembersTitles> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationMembersTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CorporationMembersTitles>, IList<V2CorporationMembersTitles>>(esiModel);
        }

        public IList<V2CorporationMemberTracking> MemberTracking(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_track_members_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2MemberTracking(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationMemberTracking> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationMemberTracking>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CorporationMemberTracking>, IList<V2CorporationMemberTracking>>(esiModel);
        }

        public async Task<IList<V2CorporationMemberTracking>> MemberTrackingAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_track_members_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2MemberTracking(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationMemberTracking> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationMemberTracking>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CorporationMemberTracking>, IList<V2CorporationMemberTracking>>(esiModel);
        }

        public IList<V2CorporationRoles> Roles(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2Roles(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationRoles> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationRoles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CorporationRoles>, IList<V2CorporationRoles>>(esiModel);
        }

        public async Task<IList<V2CorporationRoles>> RolesAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2Roles(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationRoles> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationRoles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CorporationRoles>, IList<V2CorporationRoles>>(esiModel);
        }

        public PagedModel<V2CorporationRolesHistory> RoleHistory(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2RolesHistory(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationRolesHistory> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationRolesHistory>>(esiRaw.Model);

            IList<V2CorporationRolesHistory> mapped = _mapper.Map<IList<EsiV2CorporationRolesHistory>, IList<V2CorporationRolesHistory>>(esiModel);

            return new PagedModel<V2CorporationRolesHistory> {CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped};
        }

        public async Task<PagedModel<V2CorporationRolesHistory>> RoleHistoryAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2RolesHistory(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationRolesHistory> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationRolesHistory>>(esiRaw.Model);

            IList<V2CorporationRolesHistory> mapped = _mapper.Map<IList<EsiV2CorporationRolesHistory>, IList<V2CorporationRolesHistory>>(esiModel);

            return new PagedModel<V2CorporationRolesHistory> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public PagedModel<V1CorporationShareholders> Shareholders(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1ShareHolders(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationShareholders> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationShareholders>>(esiRaw.Model);

            IList<V1CorporationShareholders> mapped = _mapper.Map<IList<EsiV1CorporationShareholders>, IList<V1CorporationShareholders>>(esiModel);

            return new PagedModel<V1CorporationShareholders> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public async Task<PagedModel<V1CorporationShareholders>> ShareholdersAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1ShareHolders(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationShareholders> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationShareholders>>(esiRaw.Model);

            IList<V1CorporationShareholders> mapped = _mapper.Map<IList<EsiV1CorporationShareholders>, IList<V1CorporationShareholders>>(esiModel);

            return new PagedModel<V1CorporationShareholders> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public PagedModel<V1CorporationStandings> Standings(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_standings_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Standings(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationStandings> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationStandings>>(esiRaw.Model);

            IList<V1CorporationStandings> mapped = _mapper.Map<IList<EsiV1CorporationStandings>, IList<V1CorporationStandings>>(esiModel);

            return new PagedModel<V1CorporationStandings> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public async Task<PagedModel<V1CorporationStandings>> StandingsAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_standings_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Standings(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationStandings> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationStandings>>(esiRaw.Model);

            IList<V1CorporationStandings> mapped = _mapper.Map<IList<EsiV1CorporationStandings>, IList<V1CorporationStandings>>(esiModel);

            return new PagedModel<V1CorporationStandings> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public PagedModel<V2CorporationStarbases> Starbases(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_starbases_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2Starbases(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationStarbases> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationStarbases>>(esiRaw.Model);

            IList<V2CorporationStarbases> mapped = _mapper.Map<IList<EsiV2CorporationStarbases>, IList<V2CorporationStarbases>>(esiModel);

            return new PagedModel<V2CorporationStarbases> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public async Task<PagedModel<V2CorporationStarbases>> StarbasesAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_starbases_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2Starbases(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationStarbases> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationStarbases>>(esiRaw.Model);

            IList<V2CorporationStarbases> mapped = _mapper.Map<IList<EsiV2CorporationStarbases>, IList<V2CorporationStarbases>>(esiModel);

            return new PagedModel<V2CorporationStarbases> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public V2CorporationStarbase Starbase(SsoToken token, long corporationId, int starbaseId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_starbases_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2Starbase(corporationId, starbaseId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV2CorporationStarbase esiModel = JsonConvert.DeserializeObject<EsiV2CorporationStarbase>(esiRaw.Model);

            return _mapper.Map<V2CorporationStarbase>(esiModel);
        }

        public async Task<V2CorporationStarbase> StarbaseAsync(SsoToken token, long corporationId, int starbaseId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_starbases_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2Starbase(corporationId, starbaseId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV2CorporationStarbase esiModel = JsonConvert.DeserializeObject<EsiV2CorporationStarbase>(esiRaw.Model);

            return _mapper.Map<V2CorporationStarbase>(esiModel);
        }

        public PagedModel<V4CorporationStructures> Structures(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_structures_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV4Structures(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV4CorporationStructures> esiModel = JsonConvert.DeserializeObject<IList<EsiV4CorporationStructures>>(esiRaw.Model);

            IList<V4CorporationStructures> mapped = _mapper.Map<IList<EsiV4CorporationStructures>, IList<V4CorporationStructures>>(esiModel);

            return new PagedModel<V4CorporationStructures> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public async Task<PagedModel<V4CorporationStructures>> StructuresAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_structures_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV4Structures(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV4CorporationStructures> esiModel = JsonConvert.DeserializeObject<IList<EsiV4CorporationStructures>>(esiRaw.Model);

            IList<V4CorporationStructures> mapped = _mapper.Map<IList<EsiV4CorporationStructures>, IList<V4CorporationStructures>>(esiModel);

            return new PagedModel<V4CorporationStructures> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public IList<V1CorporationTitles> Titles(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1CorporationTitles(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationTitles> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationTitles>, IList<V1CorporationTitles>>(esiModel);
        }

        public async Task<IList<V1CorporationTitles>> TitlesAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1CorporationTitles(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationTitles> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationTitles>, IList<V1CorporationTitles>>(esiModel);
        }

        public IList<int> NpcCorps()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2NpcCorps(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> NpcCorpsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2NpcCorps(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }
    }
}
