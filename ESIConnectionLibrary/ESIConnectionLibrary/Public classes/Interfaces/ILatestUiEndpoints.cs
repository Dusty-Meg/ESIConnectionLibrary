using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestUiEndpoints
    {
        void AddSolarSystemIntoAutopilotWaypoint(SsoToken token, bool addToBeginning, bool clearOtherWaypoints, int destinationId);
        Task AddSolarSystemIntoAutopilotWaypointAsync(SsoToken token, bool addToBeginning, bool clearOtherWaypoints, int destinationId);
        void OpenContractWindow(SsoToken token, int contractId);
        Task OpenContractWindowAsync(SsoToken token, int contractId);
        void OpenInformationWindow(SsoToken token, int targetId);
        Task OpenInformationWindowAsync(SsoToken token, int targetId);
        void OpenMarketWindow(SsoToken token, int typeId);
        Task OpenMarketWindowAsync(SsoToken token, int typeId);
        void OpenNewMailWindow(SsoToken token, V1UiSendMail sendMail);
        Task OpenNewMailWindowAsync(SsoToken token, V1UiSendMail sendMail);
    }
}