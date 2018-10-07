using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1Incursion
    {
        public int ConstellationId { get; set; }
        public int FactionId { get; set; }
        public bool HasBoss { get; set; }
        public IList<int> InfestedSolarSystems { get; set; }
        public float Influence { get; set; }
        public int StagingSolarSystemId { get; set; }
        public V1IncursionState State { get; set; }
        public string Type { get; set; }
    }
}