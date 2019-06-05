using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestIncursionsEndpoints : ILatestIncursionsEndpoints
    {
        private readonly IInternalLatestIncursions _internalLatestIncursions;

        public LatestIncursionsEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestIncursions = new InternalLatestIncursions(null, userAgent, testing);
        }

        internal LatestIncursionsEndpoints(string userAgent, IWebClient webClient, bool testing = false)
        {
            _internalLatestIncursions = new InternalLatestIncursions(webClient, userAgent, testing);
        }

        public IList<V1Incursion> Incursions()
        {
            return _internalLatestIncursions.Incursions();
        }

        public async Task<IList<V1Incursion>> IncursionsAsync()
        {
            return await _internalLatestIncursions.IncursionsAsync();
        }
    }
}
