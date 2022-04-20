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

        public IList<V2CorporationAllianceHistory> AllianceHistory(long corporationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2AllianceHistory(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV2CorporationAllianceHistory> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationAllianceHistory>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CorporationAllianceHistory>, IList<V2CorporationAllianceHistory>>(esiModel);
        }

        public async Task<IList<V2CorporationAllianceHistory>> AllianceHistoryAsync(long corporationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2AllianceHistory(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV2CorporationAllianceHistory> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationAllianceHistory>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CorporationAllianceHistory>, IList<V2CorporationAllianceHistory>>(esiModel);
        }

        public PagedModel<V2CorporationBlueprints> Blueprints(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_blueprints_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2Bluepints(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationBlueprints> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationBlueprints>>(esiRaw.Model);

            IList<V2CorporationBlueprints> mapped = _mapper.Map<IList<EsiV2CorporationBlueprints>, IList<V2CorporationBlueprints>>(esiModel);

            return new PagedModel<V2CorporationBlueprints> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V2CorporationBlueprints>> BlueprintsAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_blueprints_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2Bluepints(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CorporationBlueprints> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationBlueprints>>(esiRaw.Model);

            IList<V2CorporationBlueprints> mapped = _mapper.Map<IList<EsiV2CorporationBlueprints>, IList<V2CorporationBlueprints>>(esiModel);

            return new PagedModel<V2CorporationBlueprints>{ Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public PagedModel<V2CorporationContainerLogs> ContainerLogs(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_container_logs_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2ContainersLogs(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV2CorporationContainerLogs> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationContainerLogs>>(esiRaw.Model);

            IList<V2CorporationContainerLogs> mapped = _mapper.Map<IList<EsiV2CorporationContainerLogs>, IList<V2CorporationContainerLogs>>(esiModel);

            return new PagedModel<V2CorporationContainerLogs>{ Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V2CorporationContainerLogs>> ContainerLogsAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_container_logs_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV2ContainersLogs(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV2CorporationContainerLogs> esiModel = JsonConvert.DeserializeObject<IList<EsiV2CorporationContainerLogs>>(esiRaw.Model);

            IList<V2CorporationContainerLogs> mapped = _mapper.Map<IList<EsiV2CorporationContainerLogs>, IList<V2CorporationContainerLogs>>(esiModel);

            return new PagedModel<V2CorporationContainerLogs> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
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

        public V1CorporationIcons Icons(long corporationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Icons(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1CorporationIcons esiModel = JsonConvert.DeserializeObject<EsiV1CorporationIcons>(esiRaw.Model);

            return _mapper.Map<V1CorporationIcons>(esiModel);
        }

        public async Task<V1CorporationIcons> IconsAsync(long corporationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Icons(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1CorporationIcons esiModel = JsonConvert.DeserializeObject<EsiV1CorporationIcons>(esiRaw.Model);

            return _mapper.Map<V1CorporationIcons>(esiModel);
        }

        public PagedModel<V1CorporationMedals> Medals(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_medals_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Medals(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationMedals> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationMedals>>(esiRaw.Model);

            IList<V1CorporationMedals> mapped = _mapper.Map<IList<EsiV1CorporationMedals>, IList<V1CorporationMedals>>(esiModel);

            return new PagedModel<V1CorporationMedals>{ CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public async Task<PagedModel<V1CorporationMedals>> MedalsAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_medals_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Medals(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationMedals> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationMedals>>(esiRaw.Model);

            IList<V1CorporationMedals> mapped = _mapper.Map<IList<EsiV1CorporationMedals>, IList<V1CorporationMedals>>(esiModel);

            return new PagedModel<V1CorporationMedals> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public PagedModel<V1CorporationMedalsIssued> IssuedMedals(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_medals_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1MedalsIssued(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationMedalsIssued> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationMedalsIssued>>(esiRaw.Model);

            IList<V1CorporationMedalsIssued> mapped = _mapper.Map<IList<EsiV1CorporationMedalsIssued>, IList<V1CorporationMedalsIssued>>(esiModel);

            return new PagedModel<V1CorporationMedalsIssued> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public async Task<PagedModel<V1CorporationMedalsIssued>> IssuedMedalsAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_medals_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1MedalsIssued(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationMedalsIssued> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationMedalsIssued>>(esiRaw.Model);

            IList<V1CorporationMedalsIssued> mapped = _mapper.Map<IList<EsiV1CorporationMedalsIssued>, IList<V1CorporationMedalsIssued>>(esiModel);

            return new PagedModel<V1CorporationMedalsIssued> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public IList<int> Members(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV3Members(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> MembersAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV3Members(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public int MembersLimit(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_track_members_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1MembersLimit(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            return JsonConvert.DeserializeObject<int>(esiRaw.Model);
        }

        public async Task<int> MembersLimitAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_track_members_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1MembersLimit(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            return JsonConvert.DeserializeObject<int>(esiRaw.Model);
        }

        public IList<V1CorporationMembersTitles> MembersTitles(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1CorporationMemberTitles(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationMembersTitles> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationMembersTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationMembersTitles>, IList<V1CorporationMembersTitles>>(esiModel);
        }

        public async Task<IList<V1CorporationMembersTitles>> MembersTitlesAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1CorporationMemberTitles(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationMembersTitles> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationMembersTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationMembersTitles>, IList<V1CorporationMembersTitles>>(esiModel);
        }

        public IList<V1CorporationMemberTracking> MemberTracking(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_track_members_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1MemberTracking(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationMemberTracking> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationMemberTracking>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationMemberTracking>, IList<V1CorporationMemberTracking>>(esiModel);
        }

        public async Task<IList<V1CorporationMemberTracking>> MemberTrackingAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_track_members_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1MemberTracking(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationMemberTracking> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationMemberTracking>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationMemberTracking>, IList<V1CorporationMemberTracking>>(esiModel);
        }

        public IList<V1CorporationRoles> Roles(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Roles(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationRoles> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationRoles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationRoles>, IList<V1CorporationRoles>>(esiModel);
        }

        public async Task<IList<V1CorporationRoles>> RolesAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Roles(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationRoles> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationRoles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationRoles>, IList<V1CorporationRoles>>(esiModel);
        }

        public PagedModel<V1CorporationRolesHistory> RoleHistory(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1RolesHistory(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationRolesHistory> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationRolesHistory>>(esiRaw.Model);

            IList<V1CorporationRolesHistory> mapped = _mapper.Map<IList<EsiV1CorporationRolesHistory>, IList<V1CorporationRolesHistory>>(esiModel);

            return new PagedModel<V1CorporationRolesHistory> {CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped};
        }

        public async Task<PagedModel<V1CorporationRolesHistory>> RoleHistoryAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1RolesHistory(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationRolesHistory> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationRolesHistory>>(esiRaw.Model);

            IList<V1CorporationRolesHistory> mapped = _mapper.Map<IList<EsiV1CorporationRolesHistory>, IList<V1CorporationRolesHistory>>(esiModel);

            return new PagedModel<V1CorporationRolesHistory> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
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

        public PagedModel<V1CorporationStarbases> Starbases(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_starbases_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Starbases(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationStarbases> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationStarbases>>(esiRaw.Model);

            IList<V1CorporationStarbases> mapped = _mapper.Map<IList<EsiV1CorporationStarbases>, IList<V1CorporationStarbases>>(esiModel);

            return new PagedModel<V1CorporationStarbases> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public async Task<PagedModel<V1CorporationStarbases>> StarbasesAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_starbases_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Starbases(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationStarbases> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CorporationStarbases>>(esiRaw.Model);

            IList<V1CorporationStarbases> mapped = _mapper.Map<IList<EsiV1CorporationStarbases>, IList<V1CorporationStarbases>>(esiModel);

            return new PagedModel<V1CorporationStarbases> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public V1CorporationStarbase Starbase(SsoToken token, long corporationId, int starbaseId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_starbases_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Starbase(corporationId, starbaseId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV1CorporationStarbase esiModel = JsonConvert.DeserializeObject<EsiV1CorporationStarbase>(esiRaw.Model);

            return _mapper.Map<V1CorporationStarbase>(esiModel);
        }

        public async Task<V1CorporationStarbase> StarbaseAsync(SsoToken token, long corporationId, int starbaseId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_starbases_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1Starbase(corporationId, starbaseId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV1CorporationStarbase esiModel = JsonConvert.DeserializeObject<EsiV1CorporationStarbase>(esiRaw.Model);

            return _mapper.Map<V1CorporationStarbase>(esiModel);
        }

        public PagedModel<V3CorporationStructures> Structures(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_structures_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV3Structures(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3CorporationStructures> esiModel = JsonConvert.DeserializeObject<IList<EsiV3CorporationStructures>>(esiRaw.Model);

            IList<V3CorporationStructures> mapped = _mapper.Map<IList<EsiV3CorporationStructures>, IList<V3CorporationStructures>>(esiModel);

            return new PagedModel<V3CorporationStructures> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
        }

        public async Task<PagedModel<V3CorporationStructures>> StructuresAsync(SsoToken token, long corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_structures_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV3Structures(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3CorporationStructures> esiModel = JsonConvert.DeserializeObject<IList<EsiV3CorporationStructures>>(esiRaw.Model);

            IList<V3CorporationStructures> mapped = _mapper.Map<IList<EsiV3CorporationStructures>, IList<V3CorporationStructures>>(esiModel);

            return new PagedModel<V3CorporationStructures> { CurrentPage = page, MaxPages = esiRaw.MaxPages, Model = mapped };
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
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1NpcCorps(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> NpcCorpsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1NpcCorps(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }
    }
}
