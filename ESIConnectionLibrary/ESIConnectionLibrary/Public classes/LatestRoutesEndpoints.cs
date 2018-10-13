using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestRoutesEndpoints : ILatestRoutesEndpoints
    {
        private readonly IInternalLatestRoutes _internalLatestRoutes;

        public LatestRoutesEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestRoutes = new InternalLatestRoutes(null, userAgent, testing);
        }

        public IList<int> Route(int origin, int destination, V1RoutesFlag flag, IList<int> avoid, IList<IList<int>> connections)
        {
            return _internalLatestRoutes.Route(origin, destination, flag, avoid, connections);
        }

        public async Task<IList<int>> RouteAsync(int origin, int destination, V1RoutesFlag flag, IList<int> avoid, IList<IList<int>> connections)
        {
            return await _internalLatestRoutes.RouteAsync(origin, destination, flag, avoid, connections);
        }
    }
}
