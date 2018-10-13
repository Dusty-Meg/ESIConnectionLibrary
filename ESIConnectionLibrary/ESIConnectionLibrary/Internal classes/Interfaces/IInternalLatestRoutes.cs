using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestRoutes
    {
        IList<int> Route(int origin, int destination, V1RoutesFlag flag, IList<int> avoid, IList<IList<int>> connections);
        Task<IList<int>> RouteAsync(int origin, int destination, V1RoutesFlag flag, IList<int> avoid, IList<IList<int>> connections);
    }
}