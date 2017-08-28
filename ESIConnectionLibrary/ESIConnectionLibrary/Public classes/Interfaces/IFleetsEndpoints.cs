using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface IFleetsEndpoints
    {
        GetFleet GetFleet(SsoToken token, long fleetId);
    }
}