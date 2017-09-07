using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalKillmails
    {
        GetSingleKillmail GetSingleKillmail(int killmailId, string killmailHash);
    }
}