using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2UniverseStation
    {
        public float MaxDockableShipVolume { get; set; }
        public string Name { get; set; }
        public float OfficeRentalCost { get; set; }
        public int? Owner { get; set; }
        public Position Position { get; set; }
        public int? RaceId { get; set; }
        public float ReprocessingEfficiency { get; set; }
        public float ReprocessingStationsTake { get; set; }
        public IList<V2UniverseStationServices> Services { get; set; }
        public int StationId { get; set; }
        public int SystemId { get; set; }
        public int TypeId { get; set; }
    }
}