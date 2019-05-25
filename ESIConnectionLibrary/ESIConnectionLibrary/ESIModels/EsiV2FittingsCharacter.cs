using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2FittingsCharacter
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "fitting_id")]
        public int FittingId { get; set; }

        [JsonProperty(PropertyName = "items")]
        public IList<EsiV2FittingsCharacterItem> Items { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ship_type_id")]
        public int ShipTypeId { get; set; }
    }
}
