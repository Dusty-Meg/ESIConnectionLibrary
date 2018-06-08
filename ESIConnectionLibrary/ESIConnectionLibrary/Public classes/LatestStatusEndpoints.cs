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

        public V1Status GetStatus()
        {
            return _internalLatestStatus.GetStatus();
        }

        public async Task<V1Status> GetStatusAsync()
        {
            return await _internalLatestStatus.GetStatusAsync();
        }
    }
}
