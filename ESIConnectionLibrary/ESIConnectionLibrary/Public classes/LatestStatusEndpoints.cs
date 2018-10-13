using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestStatusEndpoints : ILatestStatusEndpoints
    {
        private readonly IInternalLatestStatus _internalLatestStatus;

        public LatestStatusEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestStatus = new InternalLatestStatus(null, userAgent, testing);
        }

        public V1Status Status()
        {
            return _internalLatestStatus.Status();
        }

        public async Task<V1Status> StatusAsync()
        {
            return await _internalLatestStatus.StatusAsync();
        }
    }
}
