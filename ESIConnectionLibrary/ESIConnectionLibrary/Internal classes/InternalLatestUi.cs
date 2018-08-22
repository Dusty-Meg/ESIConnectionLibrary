using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestUi : IInternalLatestUi
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestUi(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public void AddSolarSystemIntoAutopilotWaypoint(SsoToken token, bool addToBeginning, bool clearOtherWaypoints, int destinationId)
        {
            StaticMethods.CheckToken(token, UiScopes.esi_ui_write_waypoint_v1);

            string url = StaticConnectionStrings.UiV2AddWaypoint(addToBeginning, clearOtherWaypoints, destinationId);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public async Task AddSolarSystemIntoAutopilotWaypointAsync(SsoToken token, bool addToBeginning, bool clearOtherWaypoints, int destinationId)
        {
            StaticMethods.CheckToken(token, UiScopes.esi_ui_write_waypoint_v1);

            string url = StaticConnectionStrings.UiV2AddWaypoint(addToBeginning, clearOtherWaypoints, destinationId);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public void OpenContractWindow(SsoToken token, int contractId)
        {
            StaticMethods.CheckToken(token, UiScopes.esi_ui_open_window_v1);

            string url = StaticConnectionStrings.UiV1OpenContractWindow(contractId);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public async Task OpenContractWindowAsync(SsoToken token, int contractId)
        {
            StaticMethods.CheckToken(token, UiScopes.esi_ui_open_window_v1);

            string url = StaticConnectionStrings.UiV1OpenContractWindow(contractId);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public void OpenInformationWindow(SsoToken token, int targetId)
        {
            StaticMethods.CheckToken(token, UiScopes.esi_ui_open_window_v1);

            string url = StaticConnectionStrings.UiV1OpenInformationWindow(targetId);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public async Task OpenInformationWindowAsync(SsoToken token, int targetId)
        {
            StaticMethods.CheckToken(token, UiScopes.esi_ui_open_window_v1);

            string url = StaticConnectionStrings.UiV1OpenInformationWindow(targetId);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public void OpenMarketWindow(SsoToken token, int typeId)
        {
            StaticMethods.CheckToken(token, UiScopes.esi_ui_open_window_v1);

            string url = StaticConnectionStrings.UiV1OpenMarketDataWindow(typeId);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public async Task OpenMarketWindowAsync(SsoToken token, int typeId)
        {
            StaticMethods.CheckToken(token, UiScopes.esi_ui_open_window_v1);

            string url = StaticConnectionStrings.UiV1OpenMarketDataWindow(typeId);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public void OpenNewMailWindow(SsoToken token, V1UiSendMail sendMail)
        {
            StaticMethods.CheckToken(token, UiScopes.esi_ui_open_window_v1);

            string url = StaticConnectionStrings.UiV1OpenNewMailWindow();

            EsiV1UiSendMail newMail = _mapper.Map<EsiV1UiSendMail>(sendMail);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, JsonConvert.SerializeObject(newMail)));
        }

        public async Task OpenNewMailWindowAsync(SsoToken token, V1UiSendMail sendMail)
        {
            StaticMethods.CheckToken(token, UiScopes.esi_ui_open_window_v1);

            string url = StaticConnectionStrings.UiV1OpenNewMailWindow();

            EsiV1UiSendMail newMail = _mapper.Map<EsiV1UiSendMail>(sendMail);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, JsonConvert.SerializeObject(newMail)));
        }
    }
}
