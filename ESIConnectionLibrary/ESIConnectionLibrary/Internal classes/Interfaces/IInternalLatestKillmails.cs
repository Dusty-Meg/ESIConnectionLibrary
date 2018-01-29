using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestKillmails
    {
        V1GetSingleKillmail GetSingleKillmail(int killmailId, string killmailHash);
    }
}