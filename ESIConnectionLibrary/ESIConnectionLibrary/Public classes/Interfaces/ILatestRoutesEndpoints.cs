using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestRoutesEndpoints
    {
        IList<int> Route(int origin, int destination, V1RoutesFlag flag, IList<int> avoid, IList<IList<int>> connections);
        Task<IList<int>> RouteAsync(int origin, int destination, V1RoutesFlag flag, IList<int> avoid, IList<IList<int>> connections);
    }
}