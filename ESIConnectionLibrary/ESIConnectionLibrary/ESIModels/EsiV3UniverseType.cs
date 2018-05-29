using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3UniverseType
    {
        [JsonProperty(PropertyName = "capacity")]
        public long? Capacity { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "dogma_attributes")]
        public IList<EsiV3UniverseTypeDogmaAttribute> DogmaAttributes { get; set; }

        [JsonProperty(PropertyName = "dogma_effects")]
        public IList<EsiV3UniverseTypeDogmaEffect> DogmaEffects { get; set; }

        [JsonProperty(PropertyName = "graphic_id")]
        public long? GraphicId { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "icon_id")]
        public long? IconId { get; set; }

        [JsonProperty(PropertyName = "market_group_id")]
        public long? MarketGroupId { get; set; }

        [JsonProperty(PropertyName = "mass")]
        public long? Mass { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "packaged_volume")]
        public long? PackagedVolume { get; set; }

        [JsonProperty(PropertyName = "portion_size")]
        public long? PortionSize { get; set; }

        [JsonProperty(PropertyName = "published")]
        public bool Published { get; set; }

        [JsonProperty(PropertyName = "radius")]
        public long? Radius { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public long TypeId { get; set; }

        [JsonProperty(PropertyName = "volume")]
        public long? Volume { get; set; }
    }
}