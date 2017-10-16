using System.Collections.Generic;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiUniverseGetType
    {
        public long? capacity { get; set; }
        public string description { get; set; }
        public IList<EsiUniverseGetTypeDogmaAttribute> dogma_attributes { get; set; }
        public IList<EsiUniverseGetTypeDogmaEffect> dogma_effects { get; set; }
        public long? graphic_id { get; set; }
        public int group_id { get; set; }
        public long? icon_id { get; set; }
        public long? market_group_id { get; set; }
        public long? mass { get; set; }
        public string name { get; set; }
        public long? packaged_volume { get; set; }
        public long? portion_size { get; set; }
        public bool published { get; set; }
        public long? radius { get; set; }
        public long type_id { get; set; }
        public long? volume { get; set; }
    }
}