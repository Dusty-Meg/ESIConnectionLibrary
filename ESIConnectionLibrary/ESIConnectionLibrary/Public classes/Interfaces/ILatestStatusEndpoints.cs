using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestStatusEndpoints
    {
        V1Status GetStatus();
        Task<V1Status> GetStatusAsync();
    }
}