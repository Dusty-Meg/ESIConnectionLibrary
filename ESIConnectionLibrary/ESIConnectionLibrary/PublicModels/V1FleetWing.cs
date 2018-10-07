using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1FleetWing
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IList<V1FleetWingSquad> Squads { get; set; }
    }
}