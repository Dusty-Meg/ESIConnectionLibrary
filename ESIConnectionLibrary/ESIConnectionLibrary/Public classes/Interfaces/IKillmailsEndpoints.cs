using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface IKillmailsEndpoints
    {
        GetSingleKillmail GetSingleKillmail(int killmailId, string killmailHash);
    }
}