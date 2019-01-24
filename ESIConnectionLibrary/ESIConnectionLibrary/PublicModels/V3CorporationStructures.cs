using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3CorporationStructures
    {
        public int CorporationId { get; set; }
        public DateTime? FuelExpires { get; set; }
        public DateTime? NextReinforceApply { get; set; }
        public int? NextReinforceHour { get; set; }
        public int? NextReinforceWeekday { get; set; }
        public int ProfileId { get; set; }
        public int ReinforceHour { get; set; }
        public IList<V3CorporationStructuresServices> Services { get; set; }
        public V3CorporationStructuresState State { get; set; }
        public DateTime? StateTimerEnd { get; set; }
        public DateTime? StateTimerStart { get; set; }
        public long StructureId { get; set; }
        public int SystemId { get; set; }
        public int TypeId { get; set; }
        public DateTime? UnanchorsAt { get; set; }
    }
}