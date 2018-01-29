using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestFleetsEndpoints
    {
        V1GetFleet GetFleet(SsoToken token, long fleetId);
    }
}