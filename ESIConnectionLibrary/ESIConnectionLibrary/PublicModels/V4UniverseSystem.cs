using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V4UniverseSystem
    {
        public int ConstellationId { get; set; }
        public string Name { get; set; }
        public IList<V4UniverseSystemPlanets> Planets { get; set; }
        public Position Position { get; set; }
        public string SecurityClass { get; set; }
        public float SecurityStatus { get; set; }
        public int? StarId { get; set; }
        public IList<int> Stargates { get; set; }
        public IList<int> Stations { get; set; }
        public int SystemId { get; set; }
    }
}