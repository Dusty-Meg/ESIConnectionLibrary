using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalFleets
    {
        GetFleet GetFleet(SsoToken token, long fleetId);
    }
}