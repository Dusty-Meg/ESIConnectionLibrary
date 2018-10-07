using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestIncursions
    {
        IList<V1Incursion> Incursions();
        Task<IList<V1Incursion>> IncursionsAsync();
    }
}