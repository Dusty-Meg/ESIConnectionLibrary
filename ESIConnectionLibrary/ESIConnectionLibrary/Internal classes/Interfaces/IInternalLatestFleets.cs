using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestFleets
    {
        V1GetFleet GetFleet(SsoToken token, long fleetId);
    }
}