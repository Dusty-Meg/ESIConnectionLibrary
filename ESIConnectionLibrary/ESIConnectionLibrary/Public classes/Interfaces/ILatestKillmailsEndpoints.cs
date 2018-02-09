using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestKillmailsEndpoints
    {
        V1GetSingleKillmail GetSingleKillmail(int killmailId, string killmailHash);
        Task<V1GetSingleKillmail> GetSingleKillmailAsync(int killmailId, string killmailHash);
    }
}