using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestStatus
    {
        V1Status GetStatus();
        Task<V1Status> GetStatusAsync();
    }
}