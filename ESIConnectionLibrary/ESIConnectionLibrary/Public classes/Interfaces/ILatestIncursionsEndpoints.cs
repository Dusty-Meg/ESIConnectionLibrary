using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestIncursionsEndpoints
    {
        IList<V1Incursion> Incursions();
        Task<IList<V1Incursion>> IncursionsAsync();
    }
}