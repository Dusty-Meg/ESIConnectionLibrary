using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestUiEndpoints : ILatestUiEndpoints
    {
        private readonly IInternalLatestUi _internalLatestUi;

        public LatestUiEndpoints(string userAgent)
        {
            _internalLatestUi = new InternalLatestUi(null, userAgent);
        }

        internal LatestUiEndpoints(string userAgent, IWebClient webClient)
        {
            _internalLatestUi = new InternalLatestUi(webClient, userAgent);
        }

        public void AddSolarSystemIntoAutopilotWaypoint(SsoToken token, bool addToBeginning, bool clearOtherWaypoints, int destinationId)
        {
            _internalLatestUi.AddSolarSystemIntoAutopilotWaypoint(token, addToBeginning, clearOtherWaypoints, destinationId);
        }

        public async Task AddSolarSystemIntoAutopilotWaypointAsync(SsoToken token, bool addToBeginning, bool clearOtherWaypoints, int destinationId)
        {
            await _internalLatestUi.AddSolarSystemIntoAutopilotWaypointAsync(token, addToBeginning, clearOtherWaypoints, destinationId);
        }

        public void OpenContractWindow(SsoToken token, int contractId)
        {
            _internalLatestUi.OpenContractWindow(token, contractId);
        }

        public async Task OpenContractWindowAsync(SsoToken token, int contractId)
        {
            await _internalLatestUi.OpenContractWindowAsync(token, contractId);
        }

        public void OpenInformationWindow(SsoToken token, int targetId)
        {
            _internalLatestUi.OpenInformationWindow(token, targetId);
        }

        public async Task OpenInformationWindowAsync(SsoToken token, int targetId)
        {
            await _internalLatestUi.OpenInformationWindowAsync(token, targetId);
        }

        public void OpenMarketWindow(SsoToken token, int typeId)
        {
            _internalLatestUi.OpenMarketWindow(token, typeId);
        }

        public async Task OpenMarketWindowAsync(SsoToken token, int typeId)
        {
            await _internalLatestUi.OpenMarketWindowAsync(token, typeId);
        }

        public void OpenNewMailWindow(SsoToken token, V1UiSendMail sendMail)
        {
            _internalLatestUi.OpenNewMailWindow(token, sendMail);
        }

        public async Task OpenNewMailWindowAsync(SsoToken token, V1UiSendMail sendMail)
        {
            await _internalLatestUi.OpenNewMailWindowAsync(token, sendMail);
        }
    }
}
