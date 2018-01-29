using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestKillmailsEndpoints
    {
        V1GetSingleKillmail GetSingleKillmail(int killmailId, string killmailHash);
    }
}