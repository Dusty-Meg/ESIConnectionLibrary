using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestStatusEndpoints
    {
        V1Status Status();
        Task<V1Status> StatusAsync();
    }
}