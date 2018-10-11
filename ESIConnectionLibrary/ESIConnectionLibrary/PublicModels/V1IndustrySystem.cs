using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1IndustrySystem
    {
        public IList<V1IndustrySystemCostIndices> CostIndices { get; set; }
        public int SolarSystemId { get; set; }
    }
}