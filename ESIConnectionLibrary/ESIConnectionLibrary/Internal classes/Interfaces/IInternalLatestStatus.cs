using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestStatus
    {
        V1Status Status();
        Task<V1Status> StatusAsync();
    }
}